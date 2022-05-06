﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMTool.Client.Presentation.ViewModel;

namespace PIMTool.Client.Store
{
    public class ModalNavigationStore
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public bool IsOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
