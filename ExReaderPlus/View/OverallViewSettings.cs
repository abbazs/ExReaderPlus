﻿using System;
using ExReaderPlus.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;

namespace ExReaderPlus.View {
    [Serializable]
    public class OverallViewSettings : ViewModelBasse{
        private static OverallViewSettings _instence;
        /// <summary>
        /// 用户界面设置存储
        /// </summary>
        public static OverallViewSettings Instence {
            get {
                if (_instence is null)
                    _instence = new OverallViewSettings();
                return _instence;
            }
        }

        #region Properties
        /// <summary>
        /// 富文本框文字前景色
        /// </summary>
        private Color _richTextBoxFg = Color.FromArgb(255, 8, 8, 8);
        public Color RichTextBoxFg {
            get => _richTextBoxFg;
            set => SetValue<Color>(out _richTextBoxFg, value, nameof(RichTextBoxFg));
        }

        /// <summary>
        /// 富文本框文字背景色
        /// </summary>
        private Color _richTextBoxBg = Colors.Transparent;
        public Color RichTextBoxBg {
            get => _richTextBoxBg;
            set => SetValue<Color>(out _richTextBoxBg, value, nameof(RichTextBoxBg));
        }

        /// <summary>
        /// 富文本框文字字体大小
        /// </summary>
        private float _richTextBoxSize = 18;
        public float RichTextBoxSize {
            get => _richTextBoxSize;
            set => SetValue<float>(out _richTextBoxSize, value, nameof(RichTextBoxSize));
        }

        /// <summary>
        /// 富文本框文字水平间距
        /// </summary>
        private float _richTextBoxSpace = 2;
        public float RichTextBoxSpace {
            get => _richTextBoxSpace;
            set => SetValue<float>(out _richTextBoxSpace, value, nameof(RichTextBoxSpace));
        }

        /// <summary>
        /// 富文本框文字字重
        /// </summary>
        private int _richTextBoxWeight = 400;
        public int RichTextBoxWeight {
            get => _richTextBoxWeight;
            set => SetValue<int>(out _richTextBoxWeight, value, nameof(RichTextBoxWeight));
        }

        /// <summary>
        /// 富文本框选中前景色
        /// </summary>
        private Color _richTextSelectBoxFg = Color.FromArgb(255, 8, 8, 8);
        public Color RichTextSelectBoxFg {
            get => _richTextSelectBoxFg;
            set => SetValue<Color>(out _richTextSelectBoxFg, value, nameof(RichTextSelectBoxFg));
        }

        /// <summary>
        /// 富文本框选中背景色
        /// </summary>
        private Color _richTextSelectBoxBg = Color.FromArgb(255, 115, 135, 86);
        public Color RichTextSelectBoxBg {
            get => _richTextSelectBoxBg;
            set => SetValue<Color>(out _richTextSelectBoxBg, value, nameof(RichTextSelectBoxBg));
        }

        /// <summary>
        /// 阅读界面控制条位置
        /// </summary>
        private Thickness _readingPageControlBar = new Thickness(8, 0, 8, 32);
        public Thickness ReadingPageControlBar {
            get => _readingPageControlBar;
            set => SetValue<Thickness>(out _readingPageControlBar, value, nameof(ReadingPageControlBar));
        }
        #endregion


        #region Methods

        #endregion

        #region Constructors

        #endregion
    }

}
