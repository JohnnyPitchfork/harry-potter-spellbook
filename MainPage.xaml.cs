using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FinalExamCambpellJon
{
    // API Spells URL = https://api.potterdb.com/v1/Spells?

    /// <summary>
    /// This app provides a graphical UI that allows the end user to select
    /// a spell category, which initiates an API request to the api.potterdb.com
    /// open data source.
    /// The app gets the spells that fall under that spell category and allows 
    /// the end user to itterate through records using the "Previous" and "Next"
    /// buttons.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        //Create spellData object
        //SpellData spellData = null;

        /// <summary>
        /// When the app is executed, run the MainPage class and initialize backend components
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// API request method that will send a request to the potterdb API,
        /// get JSON objects from the DB,
        /// then parses the data to C# classes, one record at a time.
        /// Finally, it maps the current records to the UI and provides 
        /// pagenation links so the user can move to the next or previous record.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="apiBaseUrl"></param>
        public async void SendHttpClientRequest(string category, string apiBaseUrl)
        {
            // Construct an empty SpellJson object in memory
            SpellJson jsonSpellDetails;

            // Create an HTTP client in memory
            HttpClient client = new HttpClient();


            // Create API URL that can be updated with prev. next buttons
            string apiUrl = $"{apiBaseUrl}{category}";

            // Send out a request to the potterdb API
            using HttpResponseMessage response = await client.GetAsync(apiUrl);

            // Check and make sure a response was received from the API
            response.EnsureSuccessStatusCode();

            // Read response and grab the content
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Get JSON Data
            jsonSpellDetails = JsonConvert.DeserializeObject<SpellJson>(jsonResponse);

            // Parse JSON data from convoluted JSON format to a SpellGlobalData Object
            SpellGlobalData.Name = jsonSpellDetails.data[0].attributes.name;
            SpellGlobalData.Creator = jsonSpellDetails.data[0].attributes.creator;
            SpellGlobalData.Effect = jsonSpellDetails.data[0].attributes.effect;
            SpellGlobalData.Hand = jsonSpellDetails.data[0].attributes.hand;
            SpellGlobalData.Image = jsonSpellDetails.data[0].attributes.image;
            SpellGlobalData.Incantation = jsonSpellDetails.data[0].attributes.incantation;
            SpellGlobalData.Light = jsonSpellDetails.data[0].attributes.light;
            SpellGlobalData.Last = jsonSpellDetails.links.last;
            SpellGlobalData.Next = jsonSpellDetails.links.next;

            if (jsonSpellDetails != null)
            {
                LabelSpellName.Text = SpellGlobalData.Name;

                // Check if image exists
                if (SpellGlobalData.Image != null)
                {
                    ImageSpellPicture.IsVisible = true;
                    ImageSpellPicture.Source = SpellGlobalData.Image;
                }
                else 
                {
                    ImageSpellPicture.IsVisible = false;
                }

                // Hide Creator row if null
                if (SpellGlobalData.Creator != null)
                {
                    LblCreator.IsVisible = true;
                    LabelCreator.IsVisible = true;
                    LabelCreator.Text = SpellGlobalData.Creator;
                }
                else 
                {
                    LabelCreator.IsVisible = false;
                    LblCreator.IsVisible = false;
                }

                // Hide Effect row if null
                if (SpellGlobalData.Effect != null)
                {
                    LblEffect.IsVisible = true;
                    LabelEffect.IsVisible = true;
                    LabelEffect.Text = SpellGlobalData.Effect;
                }
                else
                {
                    LabelEffect.IsVisible = false;
                    LblEffect.IsVisible = false;
                }

                // Hide Casting Action row if null
                if (SpellGlobalData.Hand != null)
                {
                    LabelHand.IsVisible = true;
                    LblHand.IsVisible = true;
                    LabelHand.Text = SpellGlobalData.Hand;
                }
                else
                {
                    LblHand.IsVisible = false;
                    LabelHand.IsVisible = false;
                }

                // Hide Incantation row if null
                if (SpellGlobalData.Incantation != null)
                {
                    LblIncantation.IsVisible = true;
                    LabelIncantation.IsVisible = true;
                    LabelIncantation.Text = SpellGlobalData.Incantation;
                }
                else
                {
                    LabelIncantation.IsVisible = false;
                    LblIncantation.IsVisible = false;
                }

                // Hide Light row if null
                if (SpellGlobalData.Light != null)
                {
                    LblLight.IsVisible = true;
                    LabelLight.IsVisible = true;
                    LabelLight.Text = SpellGlobalData.Light;
                }
                else
                {
                    LabelLight.IsVisible = false;
                    LblLight.IsVisible = false;
                }

                // Create or update pagenation URLs for last and next record
                var previousSpell = SpellGlobalData.Last;
                var nextSpell = SpellGlobalData.Next;
            }
        }

        /// <summary>
        /// Uploads JSON data to UI for selected spell category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PickerSpellCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the category is changed, save index
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            // if a category is selected, get the value of the current picker index
            if (selectedIndex != -1)
            {
                string selectedSpellCategory = (string)picker.ItemsSource[selectedIndex];

                string apiBaseUrl = "https://api.potterdb.com/v1/spells?page[size]=1&filter[category_cont]=";

                SendHttpClientRequest(selectedSpellCategory, apiBaseUrl);

            }
        }

        /// <summary>
        /// Pagenation link is saved to "Previous Spell" button.
        /// When the button is pushed, it loads the JSON data for the previous
        /// API record to the UI and updates the pagination links on the buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreviousSpell_Clicked(object sender, EventArgs e)
        {
            string linkPrevious = SpellGlobalData.Last;

            if (linkPrevious != null)
            {
                string catNull = "";

                SendHttpClientRequest(catNull, linkPrevious);
            }
        }

        /// <summary>
        /// Pagenation link is saved to the "Next Spell" button.
        /// When the button is pushed, it loads the JSON data for the previous
        /// API record to the UI and updates the pagenation links on the buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNextSpell_Clicked(object sender, EventArgs e)
        {
            string linkNext = SpellGlobalData.Next;

            if (linkNext != null)
            {
                string catNull = "";

                SendHttpClientRequest(catNull, linkNext);
            }

        }
    }

}
