﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrismObservesSample {
    class MainWindowViewModel : BindableBase {
        private string _input1 = "";
        public string Input1 {
            get => _input1;
            set => SetProperty(ref _input1, value);
        }

        private string _input2 = "";
        public string Input2 {
            get => _input2;
            set => SetProperty(ref _input2, value);
        }

        private string _result = "";
        public string Result {
            get => _result;
            set => SetProperty(ref _result, value);
        }
        //コンストラクタ
        public MainWindowViewModel() {
            SumCommand = new DelegateCommand(ExcuteSum, canExecuteSum)
                .ObservesProperty(()=>Input1)
                .ObservesProperty(() => Input2);

        }
        public DelegateCommand SumCommand { get; }

        //足し算の処理
        private void ExcuteSum() {
            Result = int.TryParse(Input1, out int a) + int.TryParse(Input2, out int b).ToString();
        }

        private bool canExecuteSum() {
            return (int.TryParse(Input1, out _) && int.TryParse(Input2, out int _));
        }
    }
}
