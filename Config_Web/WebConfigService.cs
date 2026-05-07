using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Config_Web
{
    /// <summary>
    /// Responsavel por toda leitura e escrita no arquivo Web.Config via XmlDocument.
    /// Opera diretamente no XML sem passar pelo ConfigurationManager, o que permite
    /// abrir qualquer Web.Config sem necessidade de ser o arquivo de configuracao
    /// do proprio executavel.
    /// </summary>
    public class WebConfigService
    {
        public string FilePath { get; private set; }

        public string FolderPath
        {
            get { return Path.GetDirectoryName(FilePath); }
        }

        public WebConfigService(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Arquivo nao encontrado.", filePath);

            FilePath = filePath;
        }

        // ─── Verificacao de criptografia ──────────────────────────────────────────

        public bool IsSectionEncrypted(string sectionName)
        {
            XmlDocument doc = LoadDocument();
            XmlNode node = doc.SelectSingleNode("/configuration/" + sectionName);
            if (node == null) return false;
            return node.Attributes != null && node.Attributes["configProtectionProvider"] != null;
        }

        // ─── Connection Strings ───────────────────────────────────────────────────

        public List<ConnectionStringEntry> LoadConnectionStrings()
        {
            XmlDocument doc = LoadDocument();
            XmlNode csNode = doc.SelectSingleNode("/configuration/connectionStrings");

            if (csNode == null)
                return new List<ConnectionStringEntry>();

            if (csNode.Attributes != null && csNode.Attributes["configProtectionProvider"] != null)
                throw new InvalidOperationException("A secao connectionStrings esta criptografada.");

            List<ConnectionStringEntry> result = new List<ConnectionStringEntry>();

            foreach (XmlNode node in csNode.SelectNodes("add"))
            {
                result.Add(new ConnectionStringEntry
                {
                    Name             = GetAttr(node, "name"),
                    ConnectionString = GetAttr(node, "connectionString"),
                    ProviderName     = GetAttr(node, "providerName")
                });
            }

            return result;
        }

        public void SaveConnectionStrings(List<ConnectionStringEntry> entries)
        {
            if (entries == null || entries.Count == 0)
                throw new ArgumentException("Deve haver pelo menos uma conexao registrada.");

            List<string> duplicates = entries
                .GroupBy(e => e.Name)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Count > 0)
                throw new ArgumentException(
                    "Existem conexoes com nomes duplicados: " + string.Join(", ", duplicates));

            XmlDocument doc = LoadDocument();
            XmlNode configNode = doc.SelectSingleNode("/configuration");

            XmlNode csNode = configNode.SelectSingleNode("connectionStrings");
            if (csNode == null)
            {
                csNode = doc.CreateElement("connectionStrings");
                configNode.AppendChild(csNode);
            }
            else
            {
                csNode.RemoveAll();
            }

            foreach (ConnectionStringEntry entry in entries)
            {
                XmlElement addNode = doc.CreateElement("add");
                addNode.SetAttribute("name", entry.Name);
                addNode.SetAttribute("connectionString", entry.ConnectionString);
                if (!string.IsNullOrEmpty(entry.ProviderName))
                    addNode.SetAttribute("providerName", entry.ProviderName);
                csNode.AppendChild(addNode);
            }

            SaveDocument(doc);
        }

        // ─── API Config ───────────────────────────────────────────────────────────

        public string LoadApiKey()
        {
            XmlDocument doc = LoadDocument();
            XmlNode apiNode = doc.SelectSingleNode("/configuration/apiConfig");

            if (apiNode == null)
                return string.Empty;

            if (apiNode.Attributes != null && apiNode.Attributes["configProtectionProvider"] != null)
                throw new InvalidOperationException("A secao apiConfig esta criptografada.");

            XmlNode keyNode = apiNode.SelectSingleNode("add[@key='ApiKey-DGS_ApiServiceRest']");
            if (keyNode == null) return string.Empty;

            return GetAttr(keyNode, "value");
        }

        public void SaveApiKey(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey) || apiKey.Trim().Length == 0)
                throw new ArgumentException("A chave API nao pode ser vazia.");

            XmlDocument doc = LoadDocument();
            XmlNode configNode = doc.SelectSingleNode("/configuration");

            EnsureApiConfigSectionDeclared(doc, configNode);

            XmlNode apiNode = configNode.SelectSingleNode("apiConfig");
            if (apiNode == null)
            {
                apiNode = doc.CreateElement("apiConfig");
                XmlNode configSections = configNode.SelectSingleNode("configSections");
                if (configSections != null)
                    configNode.InsertAfter(apiNode, configSections);
                else
                    configNode.PrependChild(apiNode);
            }
            else
            {
                // Remove quaisquer elementos add existentes para garantir unicidade
                apiNode.RemoveAll();
            }

            XmlElement addNode = doc.CreateElement("add");
            addNode.SetAttribute("key", "ApiKey-DGS_ApiServiceRest");
            addNode.SetAttribute("value", apiKey);
            apiNode.AppendChild(addNode);

            SaveDocument(doc);
        }

        // ─── Helpers privados ─────────────────────────────────────────────────────

        private void EnsureApiConfigSectionDeclared(XmlDocument doc, XmlNode configNode)
        {
            XmlNode configSections = configNode.SelectSingleNode("configSections");
            if (configSections == null)
            {
                configSections = doc.CreateElement("configSections");
                configNode.PrependChild(configSections);
            }

            XmlNode existing = configSections.SelectSingleNode("section[@name='apiConfig']");
            if (existing == null)
            {
                XmlElement sectionNode = doc.CreateElement("section");
                sectionNode.SetAttribute("name", "apiConfig");
                sectionNode.SetAttribute("type", "System.Configuration.NameValueSectionHandler");
                configSections.AppendChild(sectionNode);
            }
        }

        private XmlDocument LoadDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);
            return doc;
        }

        private void SaveDocument(XmlDocument doc)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent      = true,
                IndentChars = "  ",
                Encoding    = new UTF8Encoding(false),
                NewLineChars = "\r\n"
            };

            using (XmlWriter writer = XmlWriter.Create(FilePath, settings))
            {
                doc.Save(writer);
            }
        }

        private static string GetAttr(XmlNode node, string name)
        {
            if (node == null || node.Attributes == null) return string.Empty;
            XmlAttribute attr = node.Attributes[name];
            return attr != null ? attr.Value : string.Empty;
        }
    }
}
