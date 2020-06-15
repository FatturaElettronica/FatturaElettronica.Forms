using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FluentValidation.Results;
using FatturaElettronica.Tabelle;
using FatturaElettronica.Ordinaria;
using FatturaElettronica.Extensions;

namespace FatturaElettronica.Forms
{
    public partial class FatturaElettronicaForm : Form
    {
        FatturaOrdinaria _fattura;
        ValidationResult _result;

        public FatturaElettronicaForm()
        {
            InitializeComponent();

            InitializeControls();
            InitializeHeaderDataBindings();


        }
        private void InitializeControls() {

            salvaApri.Enabled = false;

            // DatiTrasmissione
            idPaeseTrasmittente.DisplayMember = "Descrizione";
            idPaeseTrasmittente.ValueMember = "Codice";
            idPaeseTrasmittente.DataSource = new IdPaese().List.ToList();

            formatoTrasmissione.DisplayMember = "Descrizione";
            formatoTrasmissione.ValueMember = "Codice";
            formatoTrasmissione.DataSource = new FormatoTrasmissione().List.ToList();

            provinciaAlbo.DisplayMember = "Descrizione";
            provinciaAlbo.ValueMember = "Codice";
            provinciaAlbo.DataSource = new Provincia().List.ToList();

            regimeFiscale.DisplayMember = "Descrizione";
            regimeFiscale.ValueMember = "Codice";
            regimeFiscale.DataSource = new RegimeFiscale().List.ToList();
             
            // CedentePrestatore
            idPaeseDatiAnagrafici.DisplayMember = "Descrizione";
            idPaeseDatiAnagrafici.ValueMember = "Codice";
            idPaeseDatiAnagrafici.DataSource = new IdPaese().List.ToList();
            provinciaSede.DisplayMember = "Descrizione";
            provinciaSede.ValueMember = "Codice";
            provinciaSede.DataSource = new Provincia().List.ToList();
            nazioneSede.DisplayMember = "Descrizione";
            nazioneSede.ValueMember = "Codice";
            nazioneSede.DataSource = new IdPaese().List.ToList();
            provinciaStabileOrganizzazione.DisplayMember = "Descrizione";
            provinciaStabileOrganizzazione.ValueMember = "Codice";
            provinciaStabileOrganizzazione.DataSource = new Provincia().List.ToList();
            nazioneStabileOrganizzazione.DisplayMember = "Descrizione";
            nazioneStabileOrganizzazione.ValueMember = "Codice";
            nazioneStabileOrganizzazione.DataSource = new IdPaese().List.ToList();
            ufficio.DisplayMember = "Descrizione";
            ufficio.ValueMember = "Codice";
            ufficio.DataSource = new Provincia().List.ToList();
            socioUnico.DisplayMember = "Descrizione";
            socioUnico.ValueMember = "Codice";
            socioUnico.DataSource = new SocioUnico().List.ToList();
            statoLiquidazione.DisplayMember = "Descrizione";
            statoLiquidazione.ValueMember = "Codice";
            statoLiquidazione.DataSource = new StatoLiquidazione().List.ToList();

            // RappresentanteFiscale
            idPaeseRappresentanteFiscale.DisplayMember = "Descrizione";
            idPaeseRappresentanteFiscale.ValueMember = "Codice";
            idPaeseRappresentanteFiscale.DataSource = new IdPaese().List.ToList();

            // CessionarioCommittente
            idPaeseCessionarioCommittente.DisplayMember = "Descrizione";
            idPaeseCessionarioCommittente.ValueMember = "Codice";
            var paesi = new IdPaese().List.ToList();
            paesi.Insert(0, new IdPaese() { Nome = string.Empty});
            idPaeseCessionarioCommittente.DataSource = paesi;
            nazioneCessionarioCommittente.DisplayMember = "Descrizione";
            nazioneCessionarioCommittente.ValueMember = "Codice";
            nazioneCessionarioCommittente.DataSource = new IdPaese().List.ToList();
            provinciaCessionarioCommittente.DisplayMember = "Descrizione";
            provinciaCessionarioCommittente.ValueMember = "Codice";
            provinciaCessionarioCommittente.DataSource = new Provincia().List.ToList();
            provinciaStabileOrganizzazioneCessionarioCommittente.DisplayMember = "Descrizione";
            provinciaStabileOrganizzazioneCessionarioCommittente.ValueMember = "Codice";
            provinciaStabileOrganizzazioneCessionarioCommittente.DataSource = new Provincia().List.ToList();
            nazioneStabileOrganizzazioneCessionarioCommittente.DisplayMember = "Descrizione";
            nazioneStabileOrganizzazioneCessionarioCommittente.ValueMember = "Codice";
            nazioneStabileOrganizzazioneCessionarioCommittente.DataSource = new IdPaese().List.ToList();
            idPaeseRappresentanteFiscaleCessionarioCommittente.DisplayMember = "Descrizione";
            idPaeseRappresentanteFiscaleCessionarioCommittente.ValueMember = "Codice";
            idPaeseRappresentanteFiscaleCessionarioCommittente.DataSource = new IdPaese().List.ToList();

            // TerzoIntermediario
            idPaeseTerzoIntermediario.DisplayMember = "Descrizione";
            idPaeseTerzoIntermediario.ValueMember = "Codice";
            idPaeseTerzoIntermediario.DataSource = new IdPaese().List.ToList();

            // SoggettoEmittente
            soggettoEmittente.DisplayMember = "Descrizione";
            soggettoEmittente.ValueMember = "Codice";
            soggettoEmittente.DataSource = new SoggettoEmittente().List.ToList();
        }
        private void InitializeHeaderDataBindings() {

            const string root = "FatturaElettronicaHeader.";

            // DatiTrasmissione
            var parent = root + "DatiTrasmissione.";
            SetDataBindings(progressivoInvio, parent + "ProgressivoInvio");
            SetDataBindings(formatoTrasmissione, parent + "FormatoTrasmissione");
            SetDataBindings(codiceDestinatario, parent + "CodiceDestinatario");
            SetDataBindings(PECDestinatario, parent + "PECDestinatario");

            // DatiTrasmissione.IdTrasmittente
            var child = parent + "IdTrasmittente.";
            SetDataBindings(idPaeseTrasmittente, child + "IdPaese");
            SetDataBindings(idCodiceTrasmittente, child + "IdCodice");

            // DatiTrasmissione.ContattiTrasmittente
            child = parent + "ContattiTrasmittente.";
            SetDataBindings(telefonoTrasmittente, child + "Telefono");
            SetDataBindings(emailTrasmittente, child + "Email");

            // CedentePrestatore.DatiAnagrafici
            parent = root + "CedentePrestatore.";
            child = parent + "DatiAnagrafici.";
            SetDataBindings(codiceFiscale, child + "CodiceFiscale");
            SetDataBindings(alboProfessionale, child + "AlboProfessionale");
            SetDataBindings(provinciaAlbo, child + "ProvinciaAlbo");
            SetDataBindings(numeroIscrizioneAlbo, child + "NumeroIscrizioneAlbo");
            SetDataBindings(dataIscrizioneAlbo, child + "DataIscrizioneAlbo");
            SetDataBindings(regimeFiscale, child + "RegimeFiscale");

            // CedentePrestatore.DatiAnagrafici.IdFiscaleIVA
            var subchild = child + "IdFiscaleIVA.";
            SetDataBindings(idPaeseDatiAnagrafici, subchild + "IdPaese");
            SetDataBindings(idCodiceDatiAnagrafici, subchild + "IdCodice");

            // CedentePrestatore.DatiAnagrafici.Anagrafica
            subchild = child + "Anagrafica.";
            SetDataBindings(denominazione, subchild + "Denominazione");
            SetDataBindings(nome, subchild + "Nome");
            SetDataBindings(cognome, subchild + "Cognome");
            SetDataBindings(titolo, subchild + "Titolo");
            SetDataBindings(codEORI, subchild + "CodEORI");

            // CedentePrestatore.Sede
            child = parent + "Sede.";
            SetDataBindings(indirizzoSede, child + "Indirizzo");
            SetDataBindings(numeroCivicoSede, child + "NumeroCivico");
            SetDataBindings(capSede, child + "CAP");
            SetDataBindings(comuneSede, child + "Comune");
            SetDataBindings(provinciaSede, child + "Provincia");
            SetDataBindings(nazioneSede, child + "Nazione");

            // CedentePrestatore.StabileOrganizzazione
            child = parent + "StabileOrganizzazione.";
            SetDataBindings(indirizzoStabileOrganizzazione, child + "Indirizzo");
            SetDataBindings(numeroCivicoStabileOrganizzazione, child + "NumeroCivico");
            SetDataBindings(capStabileOrganizzazione, child + "CAP");
            SetDataBindings(comuneStabileOrganizzazione, child + "Comune");
            SetDataBindings(provinciaStabileOrganizzazione, child + "Provincia");
            SetDataBindings(nazioneStabileOrganizzazione, child + "Nazione");

            // CedentePrestatore.IscrizioneREA
            child = parent + "IscrizioneRea.";
            SetDataBindings(ufficio, child + "Ufficio");
            SetDataBindings(numeroREA, child + "NumeroREA");
            SetDataBindings(capitaleSociale, child + "CapitaleSociale");
            SetDataBindings(socioUnico, child + "SocioUnico");
            SetDataBindings(statoLiquidazione, child + "StatoLiquidazione");

            // CedentePrestatore.Contatti
            child = parent + "Contatti.";
            SetDataBindings(telefono, child + "Telefono");
            SetDataBindings(fax, child + "fax");
            SetDataBindings(email, child + "Email");

            // CedentePrestatore.RiferimentoAmministrazione
            SetDataBindings(riferimentoAmministrazione, parent + "RiferimentoAmministrazione");

            // RappresentanteFiscale.DatiAnagrafici
            parent = root + "Rappresentante.";
            child = parent + "DatiAnagrafici.";
            SetDataBindings(codiceFiscaleRappresentanteFiscale, child + "CodiceFiscale");
            subchild = child + "IdFiscaleIVA.";
            SetDataBindings(idPaeseRappresentanteFiscale, subchild + "IdPaese");
            SetDataBindings(idCodiceRappresentanteFiscale, subchild + "IdCodice");
            subchild = child + "Anagrafica.";
            SetDataBindings(denominazioneRappresentanteFiscale, subchild + "Denominazione");
            SetDataBindings(nomeRappresentanteFiscale, subchild + "Nome");
            SetDataBindings(cognomeRappresentanteFiscale, subchild + "Cognome");
            SetDataBindings(titoloRappresentanteFiscale, subchild + "Titolo");
            SetDataBindings(codEORIRappresentanteFiscale, subchild + "CodEORI");

            // CessionarioCommittente.DatiAnagrafici
            parent = root + "CessionarioCommittente.";
            child = parent + "DatiAnagrafici.";
            SetDataBindings(codiceFiscaleCessionarioCommittente, child + "CodiceFiscale");
            subchild = child + "IdFiscaleIVA.";
            SetDataBindings(idPaeseCessionarioCommittente, subchild + "IdPaese");
            SetDataBindings(idCodiceCessionarioCommittente, subchild + "IdCodice");
            subchild = child + "Anagrafica.";
            SetDataBindings(denominazioneCessionarioCommittente, subchild + "Denominazione");
            SetDataBindings(nomeCessionarioCommittente, subchild + "Nome");
            SetDataBindings(cognomeCessionarioCommittente, subchild + "Cognome");
            SetDataBindings(titoloCessionarioCommittente, subchild + "Titolo");
            SetDataBindings(codEORICessionarioCommittente, subchild + "CodEORI");

            // CessionarioCommittente.Sede
            child = parent + "Sede.";
            SetDataBindings(indirizzoCessionarioCommittente, child + "Indirizzo");
            SetDataBindings(numeroCivicoCessionarioCommittente, child + "NumeroCivico");
            SetDataBindings(capCessionarioCommittente, child + "CAP");
            SetDataBindings(comuneCessionarioCommittente, child + "Comune");
            SetDataBindings(provinciaCessionarioCommittente, child + "Provincia");
            SetDataBindings(nazioneCessionarioCommittente, child + "Nazione");

            // CessionarioCommittente.StabileOrganizzazione
            child = parent + "StabileOrganizzazione.";
            SetDataBindings(indirizzoStabileOrganizzazioneCessionarioCommittente, child + "Indirizzo");
            SetDataBindings(numeroCivicoStabileOrganizzazioneCessionarioCommittente, child + "NumeroCivico");
            SetDataBindings(capStabileOrganizzazioneCessionarioCommittente, child + "CAP");
            SetDataBindings(comuneStabileOrganizzazioneCessionarioCommittente, child + "Comune");
            SetDataBindings(provinciaStabileOrganizzazioneCessionarioCommittente, child + "Provincia");
            SetDataBindings(nazioneStabileOrganizzazioneCessionarioCommittente, child + "Nazione");

            // CessionarioCommittente.RappresentanteFiscale
            child = parent + "RappresentanteFiscale.";
            subchild = child + "IdFiscaleIVA.";
            SetDataBindings(idPaeseRappresentanteFiscaleCessionarioCommittente, subchild + "IdPaese");
            SetDataBindings(idCodiceRappresentanteFiscaleCessionarioCommittente, subchild + "IdCodice");
            SetDataBindings(denominazioneRappresentanteFiscaleCessionarioCommittente, child + "Denominazione");
            SetDataBindings(nomeRappresentanteFiscaleCessionarioCommittente, child + "Nome");
            SetDataBindings(cognomeRappresentanteFiscaleCessionarioCommittente, child + "Cognome");

            // TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici
            parent = root + "TerzoIntermediarioOSoggettoEmittente.";
            child = parent + "DatiAnagrafici.";
            SetDataBindings(codiceFiscaleTerzoIntermediario, child + "CodiceFiscale");
            subchild = child + "IdFiscaleIVA.";
            SetDataBindings(idPaeseTerzoIntermediario, subchild + "IdPaese");
            SetDataBindings(idCodiceTerzoIntermediario, subchild + "IdCodice");
            subchild = child + "Anagrafica.";
            SetDataBindings(denominazioneTerzoIntermediario, subchild + "Denominazione");
            SetDataBindings(nomeTerzoIntermediario, subchild + "Nome");
            SetDataBindings(cognomeTerzoIntermediario, subchild + "Cognome");
            SetDataBindings(titoloTerzoIntermediario, subchild + "Titolo");
            SetDataBindings(codEORITerzoIntermediario, subchild + "CodEORI");

            // SoggettoEmittente
            SetDataBindings(soggettoEmittente, root + "SoggettoEmittente");
        }
        private void SetDataBindings(Control control, string dataMember) {
            string propertyName;
            var formattingEnabled = false;
            if (control.GetType() == typeof(ComboBox)){
                propertyName = "SelectedValue";
            }
            else if (control.GetType() == typeof(DateTimePicker)) {
                propertyName = "Value";
                formattingEnabled = true;
            }
            else { 
                propertyName = "Text";
            }
            control.DataBindings.Add(propertyName, bindingSource, dataMember, formattingEnabled, DataSourceUpdateMode.OnPropertyChanged);
        }

        public FatturaOrdinaria FatturaElettronica {
            get { return _fattura;}
            set {
                _fattura = value;
                bindingSource.DataSource = _fattura;
            }
        }

        private bool ConvalidaForm() {
            errori.Items.Clear();
            _result = _fattura.Validate();
            if (_result.IsValid){
                lblErrori.Text = "Nessun errore riscontrato.";
                salvaApri.Enabled = false;
                return true;
            }
            foreach (var err in _result.Errors)
            {
                var item = new ListViewItem(err.PropertyName.Replace("FatturaElettronicaHeader.", ""));
                item.SubItems.Add(err.ErrorMessage);
                item.SubItems.Add(err.ErrorCode);
                errori.Items.Add(item);
            }
            errori.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            errori.Columns[1].Width = 300;
            errori.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lblErrori.Text = "Riscontrati alcuni errori di convalida.";
            salvaApri.Enabled = true;
            return false;
        }
        private void Convalida_Click(object sender, EventArgs e) {
            if (ConvalidaForm()) {
                salvaApri.Focus();
            }
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            if (!ConvalidaForm()) {
                MessageBox.Show(this, "Ci sono errori di convalida.", "Convalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabFatturaElettronica.SelectedTab = tabConvalida;
            }
            else {
                DialogResult = DialogResult.OK;
            }
        }

        private void SalvaApri_Click(object sender, EventArgs e)
        {
            const string filename = "convalida.txt";
            using (var f = new StreamWriter(filename, false)) {
                f.WriteLine("Proprietà, Codice, Messaggio");
                foreach (var err in _result.Errors)
                    f.WriteLine($"{err.PropertyName.Replace("FatturaElettronicaHeader.", "")}, {err.ErrorCode}, {err.ErrorMessage}");
            }
            Process.Start(filename);
        }

        private void FormatoTrasmissione_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_fattura == null) return;

            if ((string)formatoTrasmissione.SelectedValue == Defaults.FormatoTrasmissione.Privati)
            {
                codiceDestinatario.MaxLength = 7;
                if (string.IsNullOrEmpty(codiceDestinatario.Text))
                {
                    codiceDestinatario.Text = "0000000";
                }
            }
            else
            {
                codiceDestinatario.MaxLength = 6;
                codiceDestinatario.Text = string.Empty;
                PECDestinatario.Text = string.Empty;
            }
        }

        private void idCodiceCessionarioCommittente_TextChanged(object sender, EventArgs e)
        {
            if (idCodiceCessionarioCommittente.Text == string.Empty)
            {
                idPaeseCessionarioCommittente.SelectedValue = string.Empty;
            }
        }
    }
}
