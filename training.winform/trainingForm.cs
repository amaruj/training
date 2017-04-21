using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace training.winform
{
    public partial class TrainingForm : Form
    {
        IInstrumentRepository _instrumentRepository = new MyInstrumentRepository();
        Pricer _pricer;
        private ObservableCollection<InstrumentViewModel> _instruments;



        public TrainingForm()
        {
            InitializeComponent();
            _instrumentRepository = new MyInstrumentRepository();
            _instrumentRepository.Init(20);

            _pricer = new Pricer(_instrumentRepository, 1);

            _instruments =
                new ObservableCollection<InstrumentViewModel>(
                    _instrumentRepository.GetInstruments().Select(instrument => new InstrumentViewModel(instrument)));
        }

        private void Start(object sender, EventArgs e)
        {           
            _pricer.Price();            
           
            dataGridView1.DataSource = _instruments;           
        }

        private void Stop(object sender, EventArgs e)
        {
            _pricer.StopPrice();
        }
    }
}
