using Bakery.Wpf.Common;
using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.DTOs;
using Covid19Screening.Persistence;
using Covid19Screening.Wpf.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Covid19Screening.Core.Enums;

namespace Covid19Screening.Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ExaminationDto> _examinations;
        private DateTime? _from;
        private DateTime? _to;
        private int _totalExaminations;
        private int _negativeExaminations;
        private int _positiveExaminations;
        private ICommand _cmdResetFilter { get; set; }
        private ICommand _addTestResult { get; set; }

        public ObservableCollection<ExaminationDto> Examinations
        {
            get => _examinations;
            set
            {
                _examinations = value;
                OnPropertyChanged();
            }
        }

        public DateTime? From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged();
                _ = LoadDataAsync();
            }
        }

        public DateTime? To
        {
            get => _to;
            set
            {
                _to = value;
                OnPropertyChanged();
                _ = LoadDataAsync();
            }
        }

        public int TotalExaminations
        {
            get { return _totalExaminations; }
            set
            {
                _totalExaminations = value;
                OnPropertyChanged();
            }
        }

        public int PositiveExaminations
        {
            get { return _negativeExaminations; }
            set
            {
                _negativeExaminations = value;
                OnPropertyChanged();
            }
        }

        public int NegativeExaminations
        {
            get { return _positiveExaminations; }
            set
            {
                _positiveExaminations = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IWindowController windowController) : base(windowController)
        {
        }

        private async Task LoadDataAsync()
        {
            if(From == null || To == null)
            {
                return;
            }

            await using IUnitOfWork uow = new UnitOfWork();
            var examinations = await uow.Examinations.GetFilteredExamination((DateTime)From, (DateTime)To);
            Examinations = new ObservableCollection<ExaminationDto>(examinations);

            CalculateStatistics();
        }

        public static async Task<MainViewModel> CreateAsync(IWindowController windowController)
        {
            var viewModel = new MainViewModel(windowController);
            await viewModel.LoadDataAsync();
            return viewModel;
        }

        public void CalculateStatistics()
        {
            NegativeExaminations = Examinations
                .Count(n => n.TestResult == TestResults.Negative);

            PositiveExaminations = Examinations
                .Count(p => p.TestResult == TestResults.Positive);

            TotalExaminations = NegativeExaminations + PositiveExaminations;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        public ICommand CmdResetFilter
        {
            get
            {
                if (_cmdResetFilter == null)
                {
                    _cmdResetFilter = new RelayCommand(
                        execute: _ =>
                        {
                            From = null;
                            To = null;
                            _ = LoadDataAsync();
                        },
                        canExecute: _ => true);
                }

                return _cmdResetFilter;
            }
        }

        public ICommand AddTestResult
        {
            get
            {
                if (_addTestResult == null)
                {
                    _addTestResult = new RelayCommand(
                        execute: _ =>
                        {
                            Controller.ShowWindow(new AddTestResultViewModel(Controller), true);
                            _ = LoadDataAsync();
                        },
                        canExecute: _ => true);
                }

                return _addTestResult;
            }
        }
    }
}
