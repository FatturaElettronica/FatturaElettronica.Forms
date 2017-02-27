using FatturaElettronica.Tabelle;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessObjects;
using System.Text;

namespace FatturaElettronica.Forms
{
    public partial class FatturaElettronicaForm : Form
    {
        Fattura _fattura;
        public FatturaElettronicaForm()
        {
            InitializeComponent();

            InitializeControls();
            InitializeHeaderDataBindings();


        }
        private void InitializeControls() {

            salvaApri.Enabled = false;

            // DatiTrasmissione
            idPaeseTrasmittente.DataSource = Country.List.ToList();
            idPaeseTrasmittente.DisplayMember = "Description";
            idPaeseTrasmittente.ValueMember = "TwoLetterCode";

            formatoTrasmissione.DataSource = new FormatoTrasmissione().List.ToList();
            formatoTrasmissione.DisplayMember = "Descrizione";
            formatoTrasmissione.ValueMember = "Sigla";

            provinciaAlbo.DataSource = new Provincia().List.ToList();
            provinciaAlbo.DisplayMember = "Descrizione";
            provinciaAlbo.ValueMember = "Sigla";

            regimeFiscale.DataSource = new RegimeFiscale().List.ToList();
            regimeFiscale.DisplayMember = "Descrizione";
            regimeFiscale.ValueMember = "Codice";
             
            // CedentePrestatore
            idPaeseDatiAnagrafici.DataSource = Country.List.ToList();
            idPaeseDatiAnagrafici.DisplayMember = "Description";
            idPaeseDatiAnagrafici.ValueMember = "TwoLetterCode";
            provinciaSede.DataSource = new Provincia().List.ToList();
            provinciaSede.DisplayMember = "Descrizione";
            provinciaSede.ValueMember = "Sigla";
            nazioneSede.DataSource = Country.List.ToList();
            nazioneSede.DisplayMember = "Description";
            nazioneSede.ValueMember = "TwoLetterCode";
            provinciaStabileOrganizzazione.DataSource = new Provincia().List.ToList();
            provinciaStabileOrganizzazione.DisplayMember = "Descrizione";
            provinciaStabileOrganizzazione.ValueMember = "Sigla";
            nazioneStabileOrganizzazione.DataSource = Country.List.ToList();
            nazioneStabileOrganizzazione.DisplayMember = "Description";
            nazioneStabileOrganizzazione.ValueMember = "TwoLetterCode";
            ufficio.DataSource = new Provincia().List.ToList();
            ufficio.DisplayMember = "Descrizione";
            ufficio.ValueMember = "Sigla";
            socioUnico.DataSource = new SocioUnico().List.ToList();
            socioUnico.DisplayMember = "Descrizione";
            socioUnico.ValueMember = "Codice";
            statoLiquidazione.DataSource = new StatoLiquidazione().List.ToList();
            statoLiquidazione.DisplayMember = "Descrizione";
            statoLiquidazione.ValueMember = "Codice";

            // RappresentanteFiscale
            idPaeseRappresentanteFiscale.DataSource = Country.List.ToList();
            idPaeseRappresentanteFiscale.DisplayMember = "Description";
            idPaeseRappresentanteFiscale.ValueMember = "TwoLetterCode";

            // CessionarioCommittente
            idPaeseCessionarioCommittente.DataSource = Country.List.ToList();
            idPaeseCessionarioCommittente.DisplayMember = "Description";
            idPaeseCessionarioCommittente.ValueMember = "TwoLetterCode";
            nazioneCessionarioCommittente.DataSource = Country.List.ToList();
            nazioneCessionarioCommittente.DisplayMember = "Description";
            nazioneCessionarioCommittente.ValueMember = "TwoLetterCode";
            provinciaCessionarioCommittente.DataSource = new Provincia().List.ToList();
            provinciaCessionarioCommittente.DisplayMember = "Descrizione";
            provinciaCessionarioCommittente.ValueMember = "Sigla";
            provinciaStabileOrganizzazioneCessionarioCommittente.DataSource = new Provincia().List.ToList();
            provinciaStabileOrganizzazioneCessionarioCommittente.DisplayMember = "Descrizione";
            provinciaStabileOrganizzazioneCessionarioCommittente.ValueMember = "Sigla";
            nazioneStabileOrganizzazioneCessionarioCommittente.DataSource = Country.List.ToList();
            nazioneStabileOrganizzazioneCessionarioCommittente.DisplayMember = "Description";
            nazioneStabileOrganizzazioneCessionarioCommittente.ValueMember = "TwoLetterCode";
            idPaeseRappresentanteFiscaleCessionarioCommittente.DataSource = Country.List.ToList();
            idPaeseRappresentanteFiscaleCessionarioCommittente.DisplayMember = "Description";
            idPaeseRappresentanteFiscaleCessionarioCommittente.ValueMember = "TwoLetterCode";

            // TerzoIntermediario
            idPaeseTerzoIntermediario.DataSource = Country.List.ToList();
            idPaeseTerzoIntermediario.DisplayMember = "Description";
            idPaeseTerzoIntermediario.ValueMember = "TwoLetterCode";

            // SoggettoEmittente
            soggettoEmittente.DataSource = new SoggettoEmittente().List.ToList();
            soggettoEmittente.DisplayMember = "Description";
            soggettoEmittente.ValueMember = "Codice";
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

        public Fattura FatturaElettronica {
            get { return _fattura;}
            set {
                _fattura = value;
                bindingSource.DataSource = _fattura;
            }
        }

        private bool ConvalidaForm() {
            // IsValid() would invoke Error() so we use the latter for convenience.
            var result = _fattura.Validate();
            if (result.IsValid){
                validationOutput.Text="Nessun errore risconrtato.";
                salvaApri.Enabled = false;
                return true;
            }
            var errors = new StringBuilder();
            foreach (var err in result.Errors)
            {
                errors.AppendLine(string.Format("{0}: {1}", err.PropertyName, err.ErrorMessage));
            }
            validationOutput.Text = errors.ToString();
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
                f.Write(validationOutput.Text);
            }
            Process.Start(filename);
        }

        private void FormatoTrasmissione_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)formatoTrasmissione.SelectedValue == Impostazioni.FormatoTrasmissione.Privati)
            {
                codiceDestinatario.MaxLength = 7;
                codiceDestinatario.Text = "0000000";
            }
            else
            {
                codiceDestinatario.MaxLength = 6;
                codiceDestinatario.Text = string.Empty;
                PECDestinatario.Text = string.Empty;
            }
        }
    }
}
