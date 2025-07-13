using Azure;
using Markdig;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Bson;
using System.ComponentModel;
using System.Net.Http;
using CosmosAPI = Microsoft.Azure.Cosmos;

namespace CosmosDBDemo
{
    public partial class CosmosDBForm : Form
    {
        private readonly IConfiguration Config;
        private readonly CosmosAPI.CosmosClient Client;
        private readonly CosmosAPI.Database Database;
        private readonly CosmosAPI.Container DBContainer;

        private readonly BindingList<Measurement> Measurements;

        public CosmosDBForm()
        {
            InitializeComponent();

            Measurements = new BindingList<Measurement>();

            GridView.AutoGenerateColumns = false;

            GridView.Columns[0].DataPropertyName = "ID";
            GridView.Columns[1].DataPropertyName = "Temperature";
            GridView.Columns[2].DataPropertyName = "Humidity";
            GridView.Columns[3].DataPropertyName = "Co2";

            var source = new BindingSource(Measurements, null);
            GridView.DataSource = source;

            //  Manage configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<CosmosDBForm>();

            Config = builder.Build();

            AzureKeyCredential credential = new AzureKeyCredential(key: Config.GetValue<string>("CosmosDB:Key")!);
            Client = new CosmosAPI.CosmosClient(Config.GetValue<string>("CosmosDB:Endpoint"), credential);
            Database = Client.GetDatabase(id: Config.GetValue<string>("CosmosDB:Database"));
            DBContainer = Database.GetContainer(id: Config.GetValue<string>("CosmosDB:Container"));
        }

        private async Task RefreshData()
        {
            try
            {
                FeedIterator<Measurement> measurementsIterator = DBContainer.GetItemQueryIterator<Measurement>();

                Measurements.Clear();

                while (measurementsIterator.HasMoreResults)
                {
                    FeedResponse<Measurement> response = await measurementsIterator.ReadNextAsync();

                    foreach (Measurement mes in response.Resource)
                    {
                        Measurements.Add(mes);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {

        }

        private async void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string temperature = TextBoxTemperature.Text;
                string humidity = TextBoxHumidity.Text;
                string co2 = TextBoxCo2.Text;

                double? temp = null;
                double? hum = null;
                double? coco2 = null;

                if(double.TryParse(temperature, out double tmpt))
                {
                    temp = tmpt;
                }
                if (double.TryParse(humidity, out double tmph))
                {
                    hum = tmph;
                }
                if (double.TryParse(co2, out double tmpc))
                {
                    coco2 = tmpc;
                }

                Measurement measurement = new Measurement();
                measurement.Temperature = temp;
                measurement.Humidity = hum;
                measurement.Co2 = coco2;

                ItemResponse<Measurement> response = await DBContainer.CreateItemAsync(measurement, new PartitionKey(measurement.ID));

                string message = "Measurement registered sucessfully!";
                MessageBoxIcon icon = MessageBoxIcon.Information;

                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    message = "Failed to register measurement!";
                    icon = MessageBoxIcon.Error;
                }

                DialogResult res = MessageBox.Show(message, "Measurement creation", MessageBoxButtons.OK, icon);
            }
            catch (Exception)
            {

            }
        }

        private async void CosmosDBForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Keys key = e.KeyCode;
                if (key == Keys.F5)
                {
                    //  Refresh
                    RefreshData();
                }
                else if (key == Keys.F1)
                {
                    //  Remove data
                    if(GridView.SelectedRows.Count <= 0)
                    {
                        return;
                    }

                    Measurement? mes = GridView.SelectedRows[0].DataBoundItem as Measurement;
                    if(mes == null)
                    {
                        return;
                    }

                    DialogResult result = MessageBox.Show("Deleting Measurement", "Are you sure you want to delete this measurement?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result != DialogResult.Yes)
                    {
                        return;
                    }

                    ItemResponse<Measurement> response = await DBContainer.DeleteItemAsync<Measurement>(mes.ID, new PartitionKey(mes.ID));

                    string message = "Measurement deleted sucessfully!";
                    MessageBoxIcon icon = MessageBoxIcon.Information;

                    if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        message = "Failed to delete measurement!";
                        icon = MessageBoxIcon.Error;
                    }
                    else
                    {
                        Measurements.Remove(mes);
                    }

                    DialogResult res = MessageBox.Show(message, "Measurement deletion", MessageBoxButtons.OK, icon);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
