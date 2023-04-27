using CardApp.Models;
//using static Android.Icu.Text.Transliterator;
//using static Java.Util.Jar.Attributes;
namespace CardApp;
public partial class CardView : ContentPage
{
	List<Card> cardList = new List<Card>();




	public CardView()
	{
        Card aCard = new Card("Maya Moore", "Minnesota Lynx", "Forward", "https://instructorc.github.io/site/slides/csharp/images/maui/maya_moore.jpg");
        Card anotherCard = new Card("Bo Jackson", "Kansas City Royals", "OutFielder", "https://instructorc.github.io/site/slides/csharp/images/maui/bo_jackson.jpg");

        //Add to list
        cardList.Add(aCard);
        cardList.Add(anotherCard);
        InitializeComponent();
		cardcollectionView.ItemsSource = cardList;
	}

	/**private void OnCounterClicked(object sender, EventArgs e)
	{		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}*/
}

