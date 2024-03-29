﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cypher_Decrypt.Classes;

namespace Cypher_Decrypt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ColumnChart chart1;
        private ColumnChart chart2;
        public MainWindow()
        {
            InitializeComponent();
            InitChart();
        }

        private void InitChart()
        {
            chart1 = new ColumnChart(300, 62, 45, 20);
            chart2 = new ColumnChart(300, 62, 45, 20);

            for (int i = 0; i < 13; i++)
            {
                chart1.Add(new Column(0, ((char)(i + 'a')).ToString()));
                chart2.Add(new Column(0, ((char)(i + 'a' + 13)).ToString()));
            }

            ColumnChart.Link(chart1, chart2);

            chart1.Draw(UpperChart);
            chart2.Draw(LowerChart);
        }
        private void UpdateChart()
        {
            int[] letters = new int[26];
            foreach (char c in InputField_LetterFrequency_TextBox.Text)
            {
                if (!char.IsLetter(c))
                    continue;
                letters[c - 'a']++;
            }

            for(int i = 0; i < 13; i++)
            {
                chart1.updateColumnByName(((char)(i + 'a')).ToString(), letters[i]);
                chart2.updateColumnByName(((char)(i + 'a' + 13)).ToString(), letters[i + 13]);
            }

            ColumnChart.Link(chart1, chart2);
            chart1.Draw(UpperChart);
            chart2.Draw(LowerChart);
        }
        private void Scan_LetterFrequency_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateChart();
        }
    }
}
