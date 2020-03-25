using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private DrinkFactory _drinkFactory;
        private PaymentHandler _paymentHandler;

        public ObservableCollection<string> LogText { get; private set; }

        public MainViewModel()
        {
            _drinkFactory = new DrinkFactory();
            _paymentHandler = new PaymentHandler();

            LogText = new ObservableCollection<string>
            {
                "Starting up...",
                "Done, what would you like to drink?"
            };

            PaymentCardUsernames = new ObservableCollection<string>(_paymentHandler.CashOnCards.Keys);
            TeaBlendOptions = new ObservableCollection<string>(_drinkFactory.TeaBlendRepository.BlendNames);
        }

        #region Drink Properties
        public string SelectedDrinkName
        {
            get { return _drinkFactory.SelectedDrink?.Name; }
        }

        public double? SelectedDrinkPrice
        {
            get { return _drinkFactory.SelectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment
        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            if (_drinkFactory.SelectedDrink != null)
            {
                if (_paymentHandler.payByCard(LogText)) DrinkPaid();
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            if (_drinkFactory.SelectedDrink != null)
                if (_paymentHandler.payByCoin(LogText, coinValue)) DrinkPaid();
        });

        private void DrinkPaid()
        {
            _drinkFactory.SelectedDrink.LogDrinkMaking(LogText);
            LogText.Add($"Finished making {_drinkFactory.SelectedDrink.GetName()}");
            LogText.Add("------------------");
            _drinkFactory.SelectedDrink = null;
        }

        public ObservableCollection<string> PaymentCardUsernames { get; }

        public double PaymentCardRemainingAmount => _paymentHandler.PaymentCardRemainingAmount;

        public string SelectedPaymentCardUsername
        {
            get { return _paymentHandler.SelectedPaymentCardUsername; }
            set
            {
                _paymentHandler.SelectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        public double RemainingPriceToPay
        {
            get { return _paymentHandler.RemainingPriceToPay; }
            set { _paymentHandler.RemainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons

        public Strength CoffeeStrength
        {
            get { return _drinkFactory.CoffeeStrength; }
            set { _drinkFactory.CoffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        public Amount SugarAmount
        {
            get { return _drinkFactory.SugarAmount; }
            set { _drinkFactory.SugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        public Amount MilkAmount
        {
            get { return _drinkFactory.MilkAmount; }
            set { _drinkFactory.MilkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }

        public ObservableCollection<string> TeaBlendOptions { get; }

        public string SelectedTeaBlendOption
        {
            get { return _drinkFactory.SelectedTeaBlendOption; }
            set { _drinkFactory.SelectedTeaBlendOption = value; RaisePropertyChanged(() => SelectedTeaBlendOption); }
        }

        private void UpdateInfoAfterNewDrink()
        {
            RemainingPriceToPay = _drinkFactory.SelectedDrink.GetPrice();
            LogText.Add($"Selected {_drinkFactory.SelectedDrink.GetName()}, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
            RaisePropertyChanged(() => SelectedDrinkName);
            RaisePropertyChanged(() => SelectedDrinkPrice);
        }

        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.CreateDrink(drinkName, LogText);
            UpdateInfoAfterNewDrink();
        });

        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.CreateDrink(drinkName, LogText, hasSugar: true);
            UpdateInfoAfterNewDrink();
        });

        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.CreateDrink(drinkName, LogText, hasMilk: true);
            UpdateInfoAfterNewDrink();
        });

        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.CreateDrink(drinkName, LogText, hasSugar: true, hasMilk: true);
            UpdateInfoAfterNewDrink();
        });
        #endregion Coffee buttons
    }
}