using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFormsIntro.MenuItems;
using XamFormsIntro.Views;

namespace XamFormsIntro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {

            InitializeComponent();

            menuList = new List<MasterPageItem>();
      
            var page1 = new MasterPageItem() { Title = "FastDelivery", Icon = "icon.png", TargetType = typeof(Page1) };
            var page2 = new MasterPageItem() { Title = "Menus", Icon = "icon.png", TargetType = typeof(Page1) };
            var page3 = new MasterPageItem() { Title = "Free Pizza", Icon = "icon.png", TargetType = typeof(Page1) };
            var page4 = new MasterPageItem() { Title = "Dining", Icon = "icon.png", TargetType = typeof(Page1) };
            var page5 = new MasterPageItem() { Title = "Parking", Icon = "icon.png", TargetType = typeof(Page1) };
            var page6 = new MasterPageItem() { Title = "LocateUs", Icon = "icon.png", TargetType = typeof(Page1) };
            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TabbedPage1)));
            this.BindingContext = new
            {
                Header = "",
                Image = "http://www3.hilton.com/resources/media/hi/GSPSCHF/en_US/img/shared/full_page_image_gallery/main/HH_food_22_675x359_FitToBoxSmallDimension_Center.jpg",
                //Footer = "         -------- Welcome To HotelPlaza --------           "
                Footer = "Welcome To Hotel Plaza",
                
            };
        }



        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}