using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;

namespace SampleUnitConverter {
    internal class MainWindowViewModel : BindableBase {

        private double metricValue = 0;　//フィールド
        public double MetricValue {
            get => metricValue;
            set {
                //this.metricValue = value;
                this.SetProperty(ref metricValue, value);
            }
        }

        private double imperialValue = 0;　//フィールド
        public double ImperialValue {
            get => imperialValue;
            set {
                //this.imperialValue = value;
                this.SetProperty(ref imperialValue, value);
            }
        }



        private MetricUnit currentMetricUnit;
        private ImperialUnit currentImperialUnit;

        //▲で呼ばれるコマンド
        public DelegateCommand ImperialUnitToMetric { get; }
        //▼で呼ばれるコマンド
        public DelegateCommand MetricToImperialUnit { get; }

        //上のComboBoxで選択されている値
        public MetricUnit CurrentMetricUnit {
            get => currentMetricUnit;
            set => SetProperty(ref currentMetricUnit, value);
        }
        //下のComboBoxで選択されている値
        public ImperialUnit CurrentImperialUnit {
            get => currentImperialUnit;
            set => SetProperty(ref currentImperialUnit, value);
        }




        public MainWindowViewModel() {
            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();

            ImperialUnitToMetric = new DelegateCommand(
                () => MetricValue = CurrentMetricUnit.FromImperialUnit(CurrentImperialUnit, ImperialValue)
                );

            MetricToImperialUnit = new DelegateCommand(
                () => ImperialValue = CurrentImperialUnit.FromMetricUnit(CurrentMetricUnit, MetricValue)
                );
        }

    }
}
