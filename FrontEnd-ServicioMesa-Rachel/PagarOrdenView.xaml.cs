using Microsoft.Maui;
using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;

namespace ProyectoProgramacion5;

public partial class PagarOrdenView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    decimal total;
    int tip;
    int people = 0;
    int MyOrderID = 0;
    public PagarOrdenView(RespLogin login, int orderID)
	{
        MyOrderID = orderID;
        InitializeComponent();
        APIModel API = new APIModel();
        API.MYURL = BaseURL + @"/Orden";
        API.Method = "GET";
        API.Accept = "*/*";
        API.ContentType = "application/json";
        API.Key = "idOrden";
        API.Value = orderID.ToString();
        API.AddParameter(API);
        API.APICall(ref API);

        if (API.Exceptions.IsError)
        {
            DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }
        else
        {
            RespLaOrden Response = JsonConvert.DeserializeObject<RespLaOrden>(API.Exceptions.ResponseText);
            if (Response.result)
            {
                txtMonto.Text = Response.laOrden.MontoOrden.ToString();
                txtMonto.IsEnabled = false;
                total = Response.laOrden.MontoOrden;
                CalculateTotal();

            }
            else
            {
                DisplayAlert("Error", Response.listaMensajesOErrores, "OK");
            }
                     
        }
    }
    private void txtMonto_Completed(object sender, EventArgs e)
    {
        total = decimal.Parse(txtMonto.Text);
        CalculateTotal();
    }
    private void CalculateTotal()
    {
        var totalTip = (total * tip) / 100;
        var tipByPerson = totalTip / int.Parse(lblNbrPerson.Text);
        lblTipperson.Text = $"{tipByPerson:C}";

        var subtotal = (total / int.Parse(lblNbrPerson.Text));
        lblSubtotal.Text = $"{subtotal:C}";

        lblTotal.Text = $"{(subtotal + tipByPerson):C}";
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
        }
    }

    private void btnminus_Clicked(object sender, EventArgs e)
    {
        int counter = int.Parse(lblNbrPerson.Text);
        if (counter > 1)
        {
            counter--;
            lblNbrPerson.Text = counter.ToString();
            if (counter == 1)
            {
                btnminus.IsEnabled = false;
            }
        }
        else
        {
            btnminus.IsEnabled = false;
        }
        CalculateTotal();
    }

    private void btnplus_Clicked(object sender, EventArgs e)
    {
        int counter = int.Parse(lblNbrPerson.Text);

        btnminus.IsEnabled = true;
        counter++;
        lblNbrPerson.Text = counter.ToString();
        CalculateTotal();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        btnminus.IsEnabled = false;
    }

    private void btnPagar_Clicked(object sender, EventArgs e)
    {
        ReqOrden reqOrden = new ReqOrden();
        reqOrden.IdOrden = MyOrderID;
        APIModel API = new APIModel();
        API.MYURL = BaseURL + @"/GestionarOrden";
        API.Method = "PUT";
        API.Accept = "*/*";
        API.ContentType = "application/json";
        string myBody = JsonConvert.SerializeObject(reqOrden);
        API.Body = myBody;
        API.APICall(ref API);

        if (API.Exceptions.IsError)
        {
            DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }
        else
        {
            RespPagarOrden jsonData = JsonConvert.DeserializeObject<RespPagarOrden>(API.Exceptions.ResponseText);
            if (jsonData.result == true)
            {
                DisplayAlert("Pago de Orden.", "la orden ha sido pagada correctamente.", "OK");
                Navigation.PopModalAsync();

            }
            else
            {
                String errores = "";
                foreach (string error in jsonData.listaMensajesOErrores)
                {
                    errores = errores + error + "\n";
                }
                DisplayAlert("Error.", errores, "OK");
            }
            
        }

    }
}