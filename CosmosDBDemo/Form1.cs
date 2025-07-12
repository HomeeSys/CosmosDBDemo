using Azure;
using CosmosAPI = Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using Microsoft.Azure.Cosmos;

namespace CosmosDBDemo
{
    public partial class Form1 : Form
    {
        private readonly IConfiguration Config;
        private readonly CosmosAPI.CosmosClient Client;
        private readonly CosmosAPI.Database Database;
        private readonly CosmosAPI.Container DBContainer;

        private readonly BindingList<Measurement> Measurements;

        public Form1()
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
                .AddUserSecrets<Form1>();

            Config = builder.Build();

            AzureKeyCredential credential = new AzureKeyCredential(key: Config.GetValue<string>("CosmosDB:Key")!);
            Client = new CosmosAPI.CosmosClient(Config.GetValue<string>("CosmosDB:Endpoint"), credential);
            Database = Client.GetDatabase(id: Config.GetValue<string>("CosmosDB:Database"));
            DBContainer = Database.GetContainer(id: Config.GetValue<string>("CosmosDB:Container"));
        }

        private async void ButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                FeedIterator<Measurement> measurementsIterator = DBContainer.GetItemQueryIterator<Measurement>();

                Measurements.Clear();

                while (measurementsIterator.HasMoreResults)
                {
                    FeedResponse<Measurement> response = await measurementsIterator.ReadNextAsync();

                    foreach(Measurement mes in response.Resource)
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

                Measurement measurement = new Measurement();
                measurement.Temperature = temperature;
                measurement.Humidity = humidity;
                measurement.Co2 = co2;

                ItemResponse<Measurement> response = await DBContainer.CreateItemAsync(measurement);

                string message = "Measurement registered sucessfully!";
                MessageBoxIcon icon = MessageBoxIcon.Information;

                if(response.StatusCode != System.Net.HttpStatusCode.Created)
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
    }
}
