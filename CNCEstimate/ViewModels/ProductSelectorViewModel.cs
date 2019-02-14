using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using DbSqlServerWorker.Models;

namespace CNCEstimate.ViewModels
{
    public class ProductSelectorViewModel : Screen
    {
        private Material _material;
        private bool _stComboListVisible;
        private List<string> _standartProductList;
        private string _selectedStandartProduct;

        public ProductSelectorViewModel(Material material)
        {
            _material = material;
            StComboListVisible = false;
        }

        public Material Material
        {
            get { return _material; }
            set
            {
                _material = value;
                OnMaterialChanged(value);
            }
        }

        public bool StComboListVisible
        {
            get { return _stComboListVisible; }
            set
            {
                _stComboListVisible = value;
                NotifyOfPropertyChange(nameof(StComboListVisible));
            }
        }

        public List<string> StandartProductList
        {
            get { return _standartProductList; }
            set
            {
                _standartProductList = value;
                NotifyOfPropertyChange(nameof(StandartProductList));
            }
        }

        public string SelectedStandartProduct
        {
            get { return _selectedStandartProduct; }
            set
            {
                _selectedStandartProduct = value;
                if (value != null)
                    OnStandartProductSelected(value);
            }
        }

        private void OnMaterialChanged(Material material)
        {
        }

        public void CreateStandartProduct()
        {
            StandartProductList = new List<string> { "Косынка", "Пластина" };
            StComboListVisible = true;
        }

        public void CloseProduct()
        {
            StandartProductList = null;
            StComboListVisible = false;
        }

        private void OnStandartProductSelected(string stProductName)
        {
            MessageBox.Show(stProductName);
        }
    }
}
