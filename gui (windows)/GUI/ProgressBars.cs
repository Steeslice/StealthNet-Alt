//RShare
//Copyright (C) 2009 Lars Regensburger, T.Norad

//This program is free software; you can redistribute it and/or
//modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; either version 2
//of the License, or (at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program; if not, write to the Free Software
//Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Regensburger.RShare
{
    internal static class ProgressBars
    {
        private unsafe static UnsafeColor[] ComputeColors(Color color, int height, double[] shadows)
        {
            if (height < 0)
                throw new ArgumentOutOfRangeException("height");
            if (shadows == null)
                throw new ArgumentNullException("shadows");

            UnsafeColor[] colors = new UnsafeColor[height];
            fixed (UnsafeColor* ptrColors = &colors[0])
            {
                UnsafeColor unsafeColor;
                for (int n = 0; n < shadows.Length; n++)
                {
                    unsafeColor = new UnsafeColor((byte)(color.R * shadows[n] + 0.5), (byte)(color.G * shadows[n] + 0.5), (byte)(color.B * shadows[n] + 0.5));
                    ptrColors[n] = unsafeColor;
                    ptrColors[colors.Length - n - 1] = unsafeColor;
                }
            }
            return colors;
        }

        private unsafe static double[] ComputeShadows(int height, int shadow)
        {
            if (height < 0)
                throw new ArgumentOutOfRangeException("height");

            int depth = 7 - shadow;
            int count = (height + 1) / 2;
            double piOverDepth = Math.PI / depth;
            double piBase = piOverDepth * (depth / 2.0 - 1);
            double increment = piOverDepth / (count - 1);
            double[] shadows = new double[count];
            fixed (double* ptrShadows = &shadows[0])
            {
                double* ptrShadow = ptrShadows;
                for (int n = 0; n < shadows.Length; n++)
                    *ptrShadow++ = Math.Sin(piBase + n * increment);
            }
            return shadows;
        }

        public unsafe static Image GetProgressBar(Download download, int width, int height, Font font)
        {
            if (download == null)
                throw new ArgumentNullException("download");
            if (width < 0)
                throw new ArgumentOutOfRangeException("width");
            if (height < 0)
                throw new ArgumentOutOfRangeException("height");
            if (font == null)
                throw new ArgumentNullException("font");

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmd = bitmap.LockBits(new Rectangle(new Point(0, 0), bitmap.Size), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            byte* pbmd;
            int y;
            int x;
            if (download.HasInformation)
            {
                int progress = (int)((download.Progress * bitmap.Width) / 100);
                int progressWidth = (int)Math.Ceiling((double)bitmap.Width / (double)download.Sectors);
                bool[] progressBarMap = new bool[width];
                ScaleLinear(download.SectorsMap, (int)download.Sectors, progressBarMap);
                if (bool.Parse(Settings.Instance["ProgressBarsHaveShadow"]))
                {
                    Color done;
                    Color current;
                    Color available;
                    if (download.IsActive)
                    {
                        done = Color.FromArgb(104, 104, 104);
                        current = Color.FromArgb(255, 208, 0);
                        if (!download.Sources.IsEmpty)
                            available = Color.FromArgb(0, 210 - 22 * (download.Sources.Count - 1) < 0 ? 0 : 210 - 22 * (download.Sources.Count - 1), 255);
                        else
                            available = Color.FromArgb(255, 0, 0);
                    }
                    else
                    {
                        done = Color.FromArgb(116, 116, 116);
                        current = Color.FromArgb(191, 168, 64);
                        if (!download.Sources.IsEmpty)
                            available = Color.FromArgb(64, 169 - 11 * (download.Sources.Count - 1) < 64 ? 64 : 169 - 11 * (download.Sources.Count - 1), 191);
                        else
                            available = Color.FromArgb(191, 64, 64);
                    }
                    double[] shadows = ComputeShadows(bitmap.Height, int.Parse(Settings.Instance["ProgressBarsShadow"]));
                    UnsafeColor[] doneColors = ComputeColors(done, bitmap.Height, shadows);
                    UnsafeColor[] currentColors = ComputeColors(current, bitmap.Height, shadows);
                    UnsafeColor[] availableColors = ComputeColors(available, bitmap.Height, shadows);
                    UnsafeColor* c;
                    fixed (bool* pSector = &progressBarMap[0])
                    {
                        fixed (UnsafeColor* pDone = &doneColors[0], pAvailable = &availableColors[0])
                        {
                            bool* p;
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                p = pSector;
                                pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                                for (x = 0; x < bitmap.Width; x++)
                                {
                                    c = *p++ ? &pDone[y] : &pAvailable[y];
                                    *pbmd++ = c->B;
                                    *pbmd++ = c->G;
                                    *pbmd++ = c->R;
                                }
                            }
                        }
                    }
                    fixed (UnsafeColor* pCurrent = &currentColors[0])
                    {
                        foreach (Download.Source source in download.Sources.Values)
                        {
                            if (source.State != Download.SourceState.Active || source.LastRequestedSector == -1)
                                continue;
                            int progressLeft = (int)Math.Floor((double)Math.Max(source.LastRequestedSector, 0) / (double)download.Sectors * (double)bitmap.Width);
                            int n;
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + progressLeft * 3;
                                for (n = 0, x = progressLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                                {
                                    c = &pCurrent[y];
                                    *pbmd++ = c->B;
                                    *pbmd++ = c->G;
                                    *pbmd++ = c->R;
                                }
                            }
                        }
                    }
                    int ph = height >= 32 ? 6 : 3;
                    shadows = ComputeShadows(ph, int.Parse(Settings.Instance["ProgressBarsShadow"]));
                    UnsafeColor[] progressColors = ComputeColors(Color.FromArgb(0, 224, 0), ph, shadows);
                    fixed (UnsafeColor* pProgress = &progressColors[0])
                    {
                        for (y = 0; y < Math.Min(ph, bitmap.Height); y++)
                        {
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                            for (x = 0; x < progress; x++)
                            {
                                c = &pProgress[y];
                                *pbmd++ = c->B;
                                *pbmd++ = c->G;
                                *pbmd++ = c->R;
                            }
                        }
                    }
                }
                else
                {
                    Color done;
                    Color current;
                    Color available;
                    if (download.IsActive)
                    {
                        done = Color.FromArgb(0, 0, 0);
                        current = Color.FromArgb(255, 208, 0);
                        if (!download.Sources.IsEmpty)
                            available = Color.FromArgb(0, 210 - 22 * (download.Sources.Count - 1) < 0 ? 0 : 210 - 22 * (download.Sources.Count - 1), 255);
                        else
                            available = Color.FromArgb(255, 0, 0);
                    }
                    else
                    {
                        done = Color.FromArgb(64, 64, 64);
                        current = Color.FromArgb(191, 168, 64);
                        if (!download.Sources.IsEmpty)
                            available = Color.FromArgb(64, 169 - 11 * (download.Sources.Count - 1) < 64 ? 64 : 169 - 11 * (download.Sources.Count - 1), 191);
                        else
                            available = Color.FromArgb(191, 64, 64);
                    }
                    Color c;
                    fixed (bool* pSector = &progressBarMap[0])
                    {
                        bool* p;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            p = pSector;
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                            for (x = 0; x < bitmap.Width; x++)
                            {
                                c = *p++ ? done : available;
                                *pbmd++ = c.B;
                                *pbmd++ = c.G;
                                *pbmd++ = c.R;
                            }
                        }
                    }
                    foreach (Download.Source source in download.Sources.Values)
                    {
                        if (source.State != Download.SourceState.Active || source.LastRequestedSector == -1)
                            continue;
                        int progressLeft = (int)Math.Floor((double)Math.Max(source.LastRequestedSector, 0) / (double)download.Sectors * (double)bitmap.Width);
                        c = current;
                        int n;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + progressLeft * 3;
                            for (n = 0, x = progressLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                            {
                                *pbmd++ = c.B;
                                *pbmd++ = c.G;
                                *pbmd++ = c.R;
                            }
                        }
                    }
                    int ph = height >= 32 ? 6 : 3;
                    Color progressForeground = Color.FromArgb(0, 150, 0);
                    Color progressBackground = Color.FromArgb(224, 224, 224);
                    for (y = 0; y < Math.Min(ph, bitmap.Height); y++)
                    {
                        pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                        for (x = 0; x < bitmap.Width; x++)
                        {
                            c = x < progress ? progressForeground : progressBackground;
                            *pbmd++ = c.B;
                            *pbmd++ = c.G;
                            *pbmd++ = c.R;
                        }
                    }
                }
            }
            else
            {
                if (bool.Parse(Settings.Instance["ProgressBarsHaveShadow"]))
                {
                    Color available;
                    if (download.IsActive)
                        available = Color.FromArgb(255, 0, 0);
                    else
                        available = Color.FromArgb(191, 64, 64);
                    double[] shadows = ComputeShadows(bitmap.Height, int.Parse(Settings.Instance["ProgressBarsShadow"]));
                    UnsafeColor[] availableColors = ComputeColors(available, bitmap.Height, shadows);
                    UnsafeColor* c;
                    fixed (UnsafeColor* pAvailable = &availableColors[0])
                    {
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                            for (x = 0; x < bitmap.Width; x++)
                            {
                                c = &pAvailable[y];
                                *pbmd++ = c->B;
                                *pbmd++ = c->G;
                                *pbmd++ = c->R;
                            }
                        }
                    }
                }
                else
                {
                    Color available;
                    if (download.IsActive)
                        available = Color.FromArgb(255, 0, 0);
                    else
                        available = Color.FromArgb(191, 64, 64);
                    Color c;
                    for (y = 0; y < bitmap.Height; y++)
                    {
                        pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                        for (x = 0; x < bitmap.Width; x++)
                        {
                            c = available;
                            *pbmd++ = c.B;
                            *pbmd++ = c.G;
                            *pbmd++ = c.R;
                        }
                    }
                }
            }
            bitmap.UnlockBits(bmd);
            Graphics graphics = Graphics.FromImage(bitmap);
            StringFormat progressStringFormat = new StringFormat();
            progressStringFormat.Alignment = StringAlignment.Center;
            progressStringFormat.LineAlignment = StringAlignment.Center;
            if (download.NoAvailableDiscSpace)
            {
                graphics.DrawString(Properties.Resources.ProgressBar_NoSpace, font, Brushes.White, new Rectangle(new Point(0, 1), new Size(bitmap.Width, bitmap.Height - 1)), progressStringFormat);
            }
            else if (!download.IsFilledWithZeros && !download.HasInformation)
            {
                graphics.DrawString(Properties.Resources.ProgressBar_NoInfo, font, Brushes.White, new Rectangle(new Point(0, 1), new Size(bitmap.Width, bitmap.Height - 1)), progressStringFormat);
            }
            else if (!download.IsFilledWithZeros && download.HasInformation && download.IsFillingWithZeros)
            {
                graphics.DrawString(Properties.Resources.ProgressBar_ZeroFilling, font, Brushes.White, new Rectangle(new Point(0, 1), new Size(bitmap.Width, bitmap.Height - 1)), progressStringFormat);
            }
            else if (download.IsActive && download.IsSourceSearchDelayActive)
            {
                graphics.DrawString(Properties.Resources.ProgressBar_Preparing, font, Brushes.White, new Rectangle(new Point(0, 1), new Size(bitmap.Width, bitmap.Height - 1)), progressStringFormat);
            }
            else if (download.HasInformation && bool.Parse(Settings.Instance["ProgressBarsShowPercent"]))
            {
                graphics.DrawString(string.Format("{0:F1}%", download.HasInformation ? download.Progress : 0F), font, Brushes.White, new Rectangle(new Point(0, 1), new Size(bitmap.Width, bitmap.Height - 1)), progressStringFormat);
            }
            progressStringFormat.Dispose();
            graphics.Dispose();
            return bitmap;
        }

        public unsafe static Image GetProgressBar(Download download, Download.Source source, int width, int height)
        {
            if (download == null)
                throw new ArgumentNullException("download");
            if (source == null)
                throw new ArgumentNullException("source");
            if (width < 0)
                throw new ArgumentOutOfRangeException("width");
            if (height < 0)
                throw new ArgumentOutOfRangeException("height");

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmd = bitmap.LockBits(new Rectangle(new Point(0, 0), bitmap.Size), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            byte* pbmd;
            int y;
            int x;
            int receivedLeft = (int)Math.Floor((double)Math.Max(source.LastReceivedSector, 0) / (double)download.Sectors * (double)bitmap.Width);
            int requestedLeft = (int)Math.Floor((double)Math.Max(source.LastRequestedSector, 0) / (double)download.Sectors * (double)bitmap.Width);
            int progressWidth = (int)Math.Ceiling((double)bitmap.Width / (double)download.Sectors);
            bool[] downloadProgressBarMap = new bool[width];
            ScaleLinear(download.SectorsMap, (int)download.Sectors, downloadProgressBarMap);
            bool[] sourceProgressBarMap = new bool[width];
            if (!source.IsComplete)
                ScaleLinear(source.SectorsMap, (int)download.Sectors, sourceProgressBarMap);
            else
                for (int n = 0; n < sourceProgressBarMap.Length; n++)
                    sourceProgressBarMap[n] = true;
            Color neither;
            Color both;
            //Color clientOnly = Color.FromArgb(0, 100, 255);
            Color clientOnly;
            Color pending = Color.FromArgb(0, 150, 0);
            Color nextPending = Color.FromArgb(255, 208, 0);
            if (bool.Parse(Settings.Instance["ProgressBarsHaveShadow"]))
            {
                neither = Color.FromArgb(240, 240, 240);
                both = Color.FromArgb(104, 104, 104);
                clientOnly = Color.FromArgb(0, 210 - 22 * (download.Sources.Count - 1) < 0 ? 0 : 210 - 22 * (download.Sources.Count - 1), 255);
                double[] shadows = ComputeShadows(bitmap.Height, int.Parse(Settings.Instance["ProgressBarsShadow"]));
                UnsafeColor[] neitherColors = ComputeColors(neither, bitmap.Height, shadows);
                UnsafeColor[] bothColors = ComputeColors(both, bitmap.Height, shadows);
                UnsafeColor[] clientOnlyColors = ComputeColors(clientOnly, bitmap.Height, shadows);
                UnsafeColor[] pendingColors = ComputeColors(pending, bitmap.Height, shadows);
                UnsafeColor[] nextPendingColors = ComputeColors(nextPending, bitmap.Height, shadows);
                UnsafeColor* c;
                fixed (bool* pDownloadSector = &downloadProgressBarMap[0], pSourceSector = &sourceProgressBarMap[0])
                {
                    fixed (UnsafeColor* pNeither = &neitherColors[0], pBoth = &bothColors[0], pClientOnly = &clientOnlyColors[0])
                    {
                        bool* pDownload;
                        bool* pSource;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            pDownload = pDownloadSector;
                            pSource = pSourceSector;
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                            for (x = 0; x < bitmap.Width; x++)
                            {
                                c = *pDownload && *pSource ? &pBoth[y] : (*pSource ? (source.State != Download.SourceState.NotNeeded ? &pClientOnly[y] : &pNeither[y]) : &pNeither[y]);
                                pDownload++;
                                pSource++;
                                *pbmd++ = c->B;
                                *pbmd++ = c->G;
                                *pbmd++ = c->R;
                            }
                        }
                    }
                }
                if (source.State == Download.SourceState.Active)
                {
                    if (source.LastReceivedSector > -1)
                        fixed (UnsafeColor* pPending = &pendingColors[0])
                        {
                            int n;
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + receivedLeft * 3;
                                for (n = 0, x = receivedLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                                {
                                    c = &pPending[y];
                                    *pbmd++ = c->B;
                                    *pbmd++ = c->G;
                                    *pbmd++ = c->R;
                                }
                            }
                        }
                    if (source.LastRequestedSector > -1)
                        fixed (UnsafeColor* pNextPending = &nextPendingColors[0])
                        {
                            int n;
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + requestedLeft * 3;
                                for (n = 0, x = requestedLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                                {
                                    c = &pNextPending[y];
                                    *pbmd++ = c->B;
                                    *pbmd++ = c->G;
                                    *pbmd++ = c->R;
                                }
                            }
                        }
                }
            }
            else
            {
                neither = Color.FromArgb(224, 224, 224);
                both = Color.FromArgb(0, 0, 0);
                clientOnly = Color.FromArgb(64, 169 - 11 * (download.Sources.Count - 1) < 64 ? 64 : 169 - 11 * (download.Sources.Count - 1), 191);
                Color c;
                fixed (bool* pDownloadSector = &downloadProgressBarMap[0], pSourceSector = &sourceProgressBarMap[0])
                {
                    bool* pDownload;
                    bool* pSource;
                    for (y = 0; y < bitmap.Height; y++)
                    {
                        pDownload = pDownloadSector;
                        pSource = pSourceSector;
                        pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                        for (x = 0; x < bitmap.Width; x++)
                        {
                            c = *pDownload && *pSource ? both : (*pSource ? (source.State != Download.SourceState.NotNeeded ? clientOnly : neither) : neither);
                            pDownload++;
                            pSource++;
                            *pbmd++ = c.B;
                            *pbmd++ = c.G;
                            *pbmd++ = c.R;
                        }
                    }
                }
                if (source.State == Download.SourceState.Active)
                {
                    if (source.LastReceivedSector > -1)
                    {
                        c = pending;
                        int n;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + receivedLeft * 3;
                            for (n = 0, x = receivedLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                            {
                                *pbmd++ = c.B;
                                *pbmd++ = c.G;
                                *pbmd++ = c.R;
                            }
                        }
                    }
                    if (source.LastRequestedSector > -1)
                    {
                        c = nextPending;
                        int n;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + requestedLeft * 3;
                            for (n = 0, x = requestedLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                            {
                                *pbmd++ = c.B;
                                *pbmd++ = c.G;
                                *pbmd++ = c.R;
                            }
                        }
                    }
                }
            }
            bitmap.UnlockBits(bmd);
            return bitmap;
        }

        public unsafe static Image GetProgressBar(Upload upload, int width, int height)
        {
            if (upload == null)
                throw new ArgumentNullException("upload");
            if (width < 0)
                throw new ArgumentOutOfRangeException("width");
            if (height < 0)
                throw new ArgumentOutOfRangeException("height");

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmd = bitmap.LockBits(new Rectangle(new Point(0, 0), bitmap.Size), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            byte* pbmd;
            int y;
            int x;
            int sentLeft = (int)Math.Floor((double)Math.Max(upload.LastSentSector, 0) / (double)upload.Sectors * (double)bitmap.Width);
            int requestedLeft = (int)Math.Floor((double)Math.Max(upload.LastRequestedSector, 0) / (double)upload.Sectors * (double)bitmap.Width);
            int progressWidth = (int)Math.Ceiling((double)bitmap.Width / (double)upload.Sectors);
            bool[] progressBarMap = new bool[width];
            ScaleLinear(upload.SectorsMap, (int)upload.Sectors, progressBarMap);
            Color neither = Color.FromArgb(224, 224, 224);
            Color both;
            Color sending = Color.FromArgb(0, 150, 0);
            Color nextSending = Color.FromArgb(255, 208, 0);
            if (bool.Parse(Settings.Instance["ProgressBarsHaveShadow"]))
            {
                both = Color.FromArgb(104, 104, 104);
                double[] shadows = ComputeShadows(bitmap.Height, int.Parse(Settings.Instance["ProgressBarsShadow"]));
                UnsafeColor[] neitherColors = ComputeColors(neither, bitmap.Height, shadows);
                UnsafeColor[] bothColors = ComputeColors(both, bitmap.Height, shadows);
                UnsafeColor[] sendingColors = ComputeColors(sending, bitmap.Height, shadows);
                UnsafeColor[] nextSendingColors = ComputeColors(nextSending, bitmap.Height, shadows);
                UnsafeColor* c;
                fixed (bool* pSector = &progressBarMap[0])
                {
                    fixed (UnsafeColor* pBoth = &bothColors[0], pNeither = &neitherColors[0])
                    {
                        bool* p;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            p = pSector;
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                            for (x = 0; x < bitmap.Width; x++)
                            {
                                c = *p++ ? &pBoth[y] : &pNeither[y];
                                *pbmd++ = c->B;
                                *pbmd++ = c->G;
                                *pbmd++ = c->R;
                            }
                        }
                    }
                }
                if (upload.IsActive)
                {
                    if (upload.LastSentSector > -1)
                        fixed (UnsafeColor* pSending = &sendingColors[0])
                        {
                            int n;
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + sentLeft * 3;
                                for (n = 0, x = sentLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                                {
                                    c = &pSending[y];
                                    *pbmd++ = c->B;
                                    *pbmd++ = c->G;
                                    *pbmd++ = c->R;
                                }
                            }
                        }
                    if (upload.LastRequestedSector > -1)
                        fixed (UnsafeColor* pNextSending = &nextSendingColors[0])
                        {
                            int n;
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + requestedLeft * 3;
                                for (n = 0, x = requestedLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                                {
                                    c = &pNextSending[y];
                                    *pbmd++ = c->B;
                                    *pbmd++ = c->G;
                                    *pbmd++ = c->R;
                                }
                            }
                        }
                }
            }
            else
            {
                both = Color.FromArgb(0, 0, 0);
                Color c;
                fixed (bool* pSector = &progressBarMap[0])
                {
                    bool* p;
                    for (y = 0; y < bitmap.Height; y++)
                    {
                        p = pSector;
                        pbmd = (byte*)bmd.Scan0 + y * bmd.Stride;
                        for (x = 0; x < bitmap.Width; x++)
                        {
                            c = *p++ ? both : neither;
                            *pbmd++ = c.B;
                            *pbmd++ = c.G;
                            *pbmd++ = c.R;
                        }
                    }
                }
                if (upload.IsActive)
                {
                    if (upload.LastSentSector > -1)
                    {
                        c = sending;
                        int n;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + sentLeft * 3;
                            for (n = 0, x = sentLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                            {
                                *pbmd++ = c.B;
                                *pbmd++ = c.G;
                                *pbmd++ = c.R;
                            }
                        }
                    }
                    if (upload.LastRequestedSector > -1)
                    {
                        c = nextSending;
                        int n;
                        for (y = 0; y < bitmap.Height; y++)
                        {
                            pbmd = (byte*)bmd.Scan0 + y * bmd.Stride + requestedLeft * 3;
                            for (n = 0, x = requestedLeft; n < progressWidth && x < bitmap.Width; n++, x++)
                            {
                                *pbmd++ = c.B;
                                *pbmd++ = c.G;
                                *pbmd++ = c.R;
                            }
                        }
                    }
                }
            }
            bitmap.UnlockBits(bmd);
            return bitmap;
        }

        private unsafe static void ScaleLinear(byte[] sectorsMap, int sectors, bool[] progressBarMap)
        {
            fixed (byte* pSector = &sectorsMap[0])
            {
                fixed (bool* pProgress = &progressBarMap[0])
                {
                    bool* pP = pProgress;
                    float da = (float)sectors / (float)progressBarMap.Length;
                    int db = (int)Math.Floor(da);
                    int length;
                    int offset = 0;
                    int sum;
                    bool last = false;
                    int m;
                    for (int n = 0; n < progressBarMap.Length; n++)
                    {
                        length = db;
                        if (offset + length < da * ((float)n + 1.0F))
                            length++;
                        if (length > 0)
                        {
                            sum = 0;
                            for (m = 0; m < length && offset < sectors; m++, offset++)
                                if ((pSector[offset / 8] & 1 << (offset % 8)) != 0)
                                    sum++;
                            last = sum == length;
                        }
                        *pP++ = last;
                    }
                }
            }
        }

        private struct UnsafeColor
        {
            public byte B;

            public byte G;

            public byte R;

            public UnsafeColor(byte r, byte g, byte b)
            {
                R = r;
                G = g;
                B = b;
            }
        }
    }
}