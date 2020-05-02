# GrandmaClicker-Game
Game project for Metropolia UAS Exchange (Project was imported from Azure DevOps thus no timeline was included).

The project was made with 6 people, all from different professions and interest. I myself had the role of being the Tech lead.
Together with the 2 other developers I discussed with them the Infrastructure and problems of the project. 
I was in charge of creating the backend of the click incrementation and the saving system as well as researching solutions for various problems.

The main idea was to focus on the ability to update the application without shipping a new APK to the marketplace, this is because data shows
that a loss of 80% of your player base occurs when mobile games get updated. Thus data like missions and items would need to be reachable outside of the APK.
With this idea in mind, the missions and items were both able to be serialized to JSON objects and thus the app can easily make an API call each instantiation to check if the json files had been updated.
