﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace Thirsty_Thirsty_Hippos.Model
{
    public class Jogo:DependencyObject, INotifyPropertyChanged, 
    {
        public Jogo
        {
            
        }

        string _jogador;
        int _pontos;


        public string Jogador
        {
            get { return _jogador; }
            set { _jogador = value;
                OnPropertyChanged("Jogador");
            }
        }

        public int Pontos
        {
            get { return _pontos; }
            set { _pontos = value;
                OnPropertyChanged("Pontos");
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }
}
