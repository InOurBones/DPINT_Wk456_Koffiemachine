using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class PaymentHandler : ViewModelBase
    {
        private Dictionary<string, double> _cashOnCards;
        private double _remainingPriceToPay;

        public string SelectedPaymentCardUsername { get; set; }

        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }

        public double PaymentCardRemainingAmount => _cashOnCards.ContainsKey(SelectedPaymentCardUsername ?? "") ? _cashOnCards[SelectedPaymentCardUsername] : 0;

        public Dictionary<string, double> CashOnCards { get { return _cashOnCards; } }

        public PaymentHandler()
        {
            _cashOnCards = new Dictionary<string, double>
            {
                ["Arjen"] = 5.0,
                ["Bert"] = 3.5,
                ["Chris"] = 7.0,
                ["Daan"] = 6.0,
            };

            SelectedPaymentCardUsername = _cashOnCards.Keys.First();
        }

        // return true if fully paid
        public bool payByCard(ObservableCollection<string> log)
        {
            double insertedMoney = _cashOnCards[SelectedPaymentCardUsername];
            if (RemainingPriceToPay <= insertedMoney)
            {
                _cashOnCards[SelectedPaymentCardUsername] = insertedMoney - RemainingPriceToPay;
                RemainingPriceToPay = 0;
            }
            else // Pay what you can, fill up with coins later
            {
                _cashOnCards[SelectedPaymentCardUsername] = 0;

                RemainingPriceToPay -= insertedMoney;
            }
            log.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
            return RemainingPriceToPay == 0;
        }

        //  return true if fully paid
        public bool payByCoin(ObservableCollection<string> log, double insertedMoney)
        {
            RemainingPriceToPay = Math.Max(Math.Round(RemainingPriceToPay - insertedMoney, 2), 0);
            log.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
            return RemainingPriceToPay == 0;
        }
    }
}
