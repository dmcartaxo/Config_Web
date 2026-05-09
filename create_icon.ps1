Add-Type -AssemblyName System.Drawing

# ──────────────────────────────────────────────────────────────────────────────
# Desenha um bitmap quadrado para o icone em uma dada resolucao.
# Design: fundo azul arredondado + "W" branco + linhas de config na base
# ──────────────────────────────────────────────────────────────────────────────
function New-IconBitmap([int]$size) {
    $bmp = New-Object System.Drawing.Bitmap($size, $size,
        [System.Drawing.Imaging.PixelFormat]::Format32bppArgb)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.SmoothingMode      = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
    $g.TextRenderingHint  = [System.Drawing.Text.TextRenderingHint]::AntiAlias
    $g.PixelOffsetMode    = [System.Drawing.Drawing2D.PixelOffsetMode]::HighQuality
    $g.Clear([System.Drawing.Color]::Transparent)

    # ── Fundo arredondado ────────────────────────────────────────────────────
    $pad = [Math]::Max(1, [int]($size * 0.04))
    $r   = [int]($size * 0.20)
    $x0  = $pad;  $y0 = $pad
    $w0  = $size - $pad * 2
    $h0  = $size - $pad * 2

    $path = New-Object System.Drawing.Drawing2D.GraphicsPath
    $path.AddArc($x0,            $y0,            $r*2, $r*2, 180, 90)
    $path.AddArc($x0+$w0-$r*2,  $y0,            $r*2, $r*2, 270, 90)
    $path.AddArc($x0+$w0-$r*2,  $y0+$h0-$r*2,  $r*2, $r*2,   0, 90)
    $path.AddArc($x0,            $y0+$h0-$r*2,  $r*2, $r*2,  90, 90)
    $path.CloseFigure()

    $gradRect = New-Object System.Drawing.Rectangle($x0, $y0, $w0, $h0)
    $c1 = [System.Drawing.Color]::FromArgb(255,  9, 50, 125)   # azul escuro
    $c2 = [System.Drawing.Color]::FromArgb(255, 22, 108, 200)  # azul medio
    $lg = New-Object System.Drawing.Drawing2D.LinearGradientBrush(
            $gradRect, $c1, $c2,
            [System.Drawing.Drawing2D.LinearGradientMode]::Vertical)
    $g.FillPath($lg, $path)
    $lg.Dispose()
    $path.Dispose()

    # ── Letra "W" (parte superior) ──────────────────────────────────────────
    $white = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::White)
    $fSz   = [float]($size * 0.52)
    $font  = New-Object System.Drawing.Font("Arial", $fSz,
                [System.Drawing.FontStyle]::Bold,
                [System.Drawing.GraphicsUnit]::Pixel)
    $sf = New-Object System.Drawing.StringFormat
    $sf.Alignment     = [System.Drawing.StringAlignment]::Center
    $sf.LineAlignment = [System.Drawing.StringAlignment]::Center

    $letterRect = New-Object System.Drawing.RectangleF(
        [float]0, [float]($size * -0.04), [float]$size, [float]($size * 0.73))
    $g.DrawString("W", $font, $white, $letterRect, $sf)
    $font.Dispose()
    $sf.Dispose()

    # ── Linhas de config (base) — apenas >= 24 px ──────────────────────────
    if ($size -ge 24) {
        $lc    = [System.Drawing.Color]::FromArgb(210, 255, 255, 255)
        $lBrush = New-Object System.Drawing.SolidBrush($lc)
        $lh    = [Math]::Max(1, [int]($size / 22))
        $lx    = [int]($size * 0.16)
        $lw    = [int]($size * 0.68)
        $ly1   = [int]($size * 0.735)
        $ly2   = [int]($size * 0.820)
        $g.FillRectangle($lBrush, $lx, $ly1, $lw,              $lh)   # linha inteira
        $g.FillRectangle($lBrush, $lx, $ly2, [int]($lw * 0.55), $lh)  # linha curta
        $lBrush.Dispose()
    }

    # ── Cadeado dourado (canto inferior direito) — apenas >= 48 px ─────────
    if ($size -ge 48) {
        $gold  = [System.Drawing.Color]::FromArgb(230, 255, 210, 40)
        $gBrush = New-Object System.Drawing.SolidBrush($gold)
        $gPen   = New-Object System.Drawing.Pen($gold, [float]([Math]::Max(1.5, $size / 24.0)))

        $lkW  = [int]($size * 0.24)
        $lkH  = [int]($size * 0.20)
        $lkX  = [int]($size * 0.64)
        $lkY  = [int]($size * 0.64)

        $bodyH = [int]($lkH * 0.60)
        $bodyY = $lkY + $lkH - $bodyH
        $g.FillRectangle($gBrush, $lkX, $bodyY, $lkW, $bodyH)

        $arcW  = [int]($lkW * 0.65)
        $arcX  = $lkX + [int](($lkW - $arcW) / 2)
        $arcH  = [int]($lkH * 0.75)
        $arcRect = New-Object System.Drawing.Rectangle($arcX, $lkY, $arcW, $arcH)
        $g.DrawArc($gPen, $arcRect, 180, 180)

        $gBrush.Dispose()
        $gPen.Dispose()
    }

    $white.Dispose()
    $g.Dispose()
    return $bmp
}

# ──────────────────────────────────────────────────────────────────────────────
# Salva multiplas resolucoes num arquivo .ico (container PNG interno).
# ──────────────────────────────────────────────────────────────────────────────
function Save-IcoFile([string]$Path, [int[]]$Sizes) {
    $streams = @()
    foreach ($s in $Sizes) {
        $bmp = New-IconBitmap $s
        $ms  = New-Object System.IO.MemoryStream
        $bmp.Save($ms, [System.Drawing.Imaging.ImageFormat]::Png)
        $bmp.Dispose()
        $streams += $ms
    }

    $fs = [System.IO.File]::Open($Path, [System.IO.FileMode]::Create)
    $bw = New-Object System.IO.BinaryWriter($fs)

    # Cabecalho ICO (6 bytes)
    $bw.Write([System.Int16]0)                   # reserved
    $bw.Write([System.Int16]1)                   # type = 1 (ICO)
    $bw.Write([System.Int16]$Sizes.Count)        # numero de imagens

    # Diretorio de entradas (16 bytes cada)
    $offset = 6 + 16 * $Sizes.Count
    for ($i = 0; $i -lt $Sizes.Count; $i++) {
        $s   = $Sizes[$i]
        $len = [System.Int32]$streams[$i].Length
        $bw.Write([System.Byte]($s -band 0xFF))  # width  (0 = 256)
        $bw.Write([System.Byte]($s -band 0xFF))  # height (0 = 256)
        $bw.Write([System.Byte]0)                # color count (0 = sem paleta)
        $bw.Write([System.Byte]0)                # reserved
        $bw.Write([System.Int16]1)               # color planes
        $bw.Write([System.Int16]32)              # bits per pixel
        $bw.Write([System.Int32]$len)            # tamanho dos dados
        $bw.Write([System.Int32]$offset)         # offset dos dados no arquivo
        $offset += $len
    }

    # Dados das imagens
    foreach ($ms in $streams) {
        $bw.Write($ms.ToArray())
        $ms.Dispose()
    }

    $bw.Flush()
    $bw.Dispose()
    $fs.Dispose()
}

# ── Ponto de entrada ─────────────────────────────────────────────────────────
$outputPath = Join-Path $PSScriptRoot "Config_Web\app.ico"
Save-IcoFile -Path $outputPath -Sizes @(16, 32, 48, 64, 256)
Write-Host "Icone gerado: $outputPath"
