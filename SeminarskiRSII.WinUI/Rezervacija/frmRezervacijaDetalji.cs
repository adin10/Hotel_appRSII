using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRSII.WinUI.Rezervacija
{
    public partial class frmRezervacijaDetalji : Form
    {
        private readonly ApiService _service = new ApiService("Rezervacija");
        private readonly ApiService _gost = new ApiService("Gost");
        private readonly ApiService _soba = new ApiService("Soba");
        private int? _id = null;
        public frmRezervacijaDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }
        private async Task loadGoste()
        {
            var list = await _gost.get<List<Model.Gost>>(null);
            list.Insert(0, new Model.Gost());
            cmbGost.ValueMember = "Id";
            cmbGost.DisplayMember = "Ime Prezime";
            cmbGost.DataSource = list;
        }
        private async Task loadSobe()
        {
            var list = await _soba.get<List<Model.Soba>>(null);
            list.Insert(0, new Model.Soba());
            cmbSoba.ValueMember = "Id";
            cmbSoba.DisplayMember = "BrojSobe";
            cmbSoba.DataSource = list;
        }
        RezervacijaInsertRequest rezervacija = new RezervacijaInsertRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            var idobj = cmbGost.SelectedValue;
            if (int.TryParse(idobj.ToString(), out int id))
            {
                rezervacija.GostId = id;
            }
            var idobj2 = cmbSoba.SelectedValue;
            if (int.TryParse(idobj2.ToString(), out int id2))
            {
                rezervacija.SobaId = id2;
            }
            rezervacija.DatumRezervacije = dtpPocetak.Value;
            rezervacija.ZavrsetakRezervacije = dtpZavrsetak.Value;
            if (_id.HasValue)
            {
                await _service.Update<Model.Rezervacija>(_id, rezervacija);
                MessageBox.Show("Uspjesno ste izmijenili podatke ");
            }
            else
            {
                await _service.Insert<Model.Rezervacija>(rezervacija);
                MessageBox.Show("Uspjesno ste dodali rezervaciju ");

            }
        }

        private async void frmRezervacijaDetalji_Load(object sender, EventArgs e)
        {
            await loadGoste();
            await loadSobe();
            if (_id.HasValue)
            {
                var rezervacija = await _service.getByID<Model.Rezervacija>(_id);
                cmbGost.SelectedValue = rezervacija.GostId;
                cmbSoba.SelectedValue = rezervacija.SobaId;
                dtpPocetak.Value = rezervacija.DatumRezervacije;
                dtpZavrsetak.Value = rezervacija.ZavrsetakRezervacije;
            }
        }
    }
}
