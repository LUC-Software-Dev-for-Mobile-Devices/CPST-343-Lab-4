# Lab 4 -  Card App Web Services: REST API and visual display 

## Introduction
In this lab, you will create a .NET MAUI application that connects to an external RESTful API. You will use the 'HttpClient' class to make API requests from this [file](https://instructorc.github.io/CPST343_lab4_resource/basketball_cards.json), and you will implement functionality to deserialize JSON objects into C# objects. The application will make use of a class called Card which has Name, Sport, Team, Position, and Image as properties. You will implement search functionality to allow the user to search for specific cards.

## Purpose + Objectives
The objective of this lab is for you to understand the usage of the **'HttpClient'** class and how to make a request across a network.  This lab will also review how to implement search and images into application.

The lab will contribute to fulfilling the weekly objectives listed below.
- Construct code to use the HttpClient class in .NET MAUI to interact with RESTful web services and retrieve data from external APIs. (Week 5 learning objective)
- Apply understanding using images in user interfaces to create visually appealing and interactive user interfaces in .NET MAUI.
- Integrate search into Collectionview
- Configure CollectionView item selection


## Steps
1. Using the code associated with this repository, download or replicate the folder structure and files within the repository. Execute the program and ensure everything is properly working.  The application should render a view that displays two sports cards contain information for Maya Moore and Bo Jackson.  Close program and continue to step 2.

2. Add the following method to your CardView code-behind file
```csharp
    public static async Task<List<Card>> getCardsFromAPI()
    {
        string URL = "https://instructorc.github.io/CPST343_lab4_resource/basketball_cards.json";
        HttpClient httpClient = new HttpClient();

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(URL); //Sends a GET Request 
            string jsonContent = await response.Content.ReadAsStringAsync();
            List<Card> cardList = JsonSerializer.Deserialize<List<Card>>(jsonContent);

            return cardList;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
```
3. Generate a new Card class for the Models folder
   1. Navigate to [https://instructorc.github.io/CPST343_lab4_resource/basketball_cards.json](https://instructorc.github.io/CPST343_lab4_resource/basketball_cards.json)
   2. Copy the JSON code URL and paste it into [https://json2csharp.com/](https://json2csharp.com/) to generate a new **Card.cs** class
      - By changing the property names to the key values within our JSON file, this helps us bypassing installing a third party to synchronize JSON key names with C# property names.
4. Add the following code to your constructor and remove code that instantiates an object and adds objects to a list.
   - Add
   ```csharp
        Task.Run(async () =>
        {
            var result = await getCardsFromAPI();
            if (result != null)
            {
                cardList = result;
                cardcollectionView.ItemsSource = cardList;
            }
        }).Wait();
   ```
   - Remove or comment out
   ```csharp
         Card aCard = new Card("Maya Moore", "Minnesota Lynx", "Forward", "https://instructorc.github.io/site/slides/csharp/images/maui/maya_moore.jpg");
        Card anotherCard = new Card("Bo Jackson", "Kansas City Royals", "OutFielder", "https://instructorc.github.io/site/slides/csharp/images/maui/bo_jackson.jpg");

        //Add to list
        cardList.Add(aCard);
        cardList.Add(anotherCard)
   ```

5. Alter the **CardView.xaml** file to reflect the change in property names for **all data bindings** 
   - Remove uppercase Name attribute
     ```csharp
      Text="{Binding Name}"
      ```
   - Add lowercase Name attribute
     ```csharp
      Text="{Binding name}"    
     ```     
6. **[EXTRA CREDIT - 2pts.]** Update your code to implement search into your interface
   - Listed below is a video that will assist you in accomplishing this task.
   - [https://loyolauniversitychicago-my.sharepoint.com/:v:/g/personal/cfulton_luc_edu/EcPsMbAilzZOv2rAQyW1afABM7WARyZJUj_VUcwDLAWOEg?e=f2Ofwd](https://loyolauniversitychicago-my.sharepoint.com/:v:/g/personal/cfulton_luc_edu/EcPsMbAilzZOv2rAQyW1afABM7WARyZJUj_VUcwDLAWOEg?e=f2Ofwd)

7. **[EXTRA CREDIT - 2pts.]** Implement CollectionView item selection by allowing the end user to select a row and passing the object selected to new page
   - Listed below is documentation on CollectionView item selection and passing data to new page
   - CollectionView item selection - [https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/collectionview/selection?view=net-maui-7.0](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/collectionview/selection?view=net-maui-7.0)
   - Navigation and passing data - [https://youtu.be/8z8qz-PePlc](https://youtu.be/8z8qz-PePlc)
8.  Record a short video using RecordScreen.io. In your recording, be sure to that displays the files you created and demo the running application using your available emulator/device. Upload the recording to the files section of your Office 365 account and make sure viewing privileges are made available. Add the URL to your recording in the comment section of Sakai.

## Submission

For this lab, all of the code pertaining to your project including the solution (.sln) file should be included within the issued repository. At the conclusion of the lab, submit the link to your issued GitHub repository.

Within Sakai, you will also need to submit a link to the recorded video demonstrating the completion of your lab
