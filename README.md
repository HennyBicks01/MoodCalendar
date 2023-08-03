# MoodCalendar
<!-- replace 'Project Title' with the title of your project -->
This project is a Mood Calendar Tracker application, designed to monitor and visualize an individual's mood over time. Users record their daily mood as either "Good," "Neutral," or "Bad," and these entries are stored persistently across sessions. The application then aggregates this data to provide visual insights on a calendar, with different colors corresponding to each mood. Additionally, it offers detailed statistics, such as the number of each type of mood and the average mood over the past month, year, and all time. By using this application, users can gain a better understanding of their emotional patterns and potentially identify triggers or trends.

## Team Members
<!-- list the names of your team members here -->
Ben Hicks

Summer Gasaway

## Required Skills
<!-- List the technical skills you needed to develop the application, the tools, or APIs (Platform specific and third party) used in the project -->
#### Xamarin.Forms: 

This is a cross-platform UI toolkit that allows developers to efficiently create native user interface layouts that can be shared across Android, iOS, and Windows Phones.

#### C# programming language: 

The entire application logic is written in C#, which is a widely-used, modern, and type-safe programming language.

*100% of our code was in C# ⬇️*

![Rubric01](photos/Rubric01.png)

#### Model-View-ViewModel (MVVM) design pattern: 

This pattern helps to cleanly separate the business and presentation logic of an application from its UI and makes it easier to unit test.

*Visual studio code representation of our logic ⬇️*

![Rubric02](photos/Rubric02.png)

#### Data persistence / Xamarin.Essentials: 

Techniques for persisting data across sessions are used. In this application, Xamarin.Essentials Preferences and a Global variable are used for data storage.

*first method stores the data for the mood and date ⬇️*

![Rubric03](photos/Rubric03.png)

*next method uses Xamarin.Essentials' Preferences class to persistently store the serialized status data in the application's settings using a simple key-value store⬇️*

![Rubric04](photos/Rubric04.png)

#### Color manipulation: 

Skills in color manipulation are required to create the mood color gradients in the calendar.

*example of some colors that appear on calendar (green = good day,  yellow is neutral, red is bad, gray is unacessable, and white is empty) ⬇️*

![Rubric05](photos/Rubric05.png)

*shows mood log screen when bad mood is clicked and background changes color to give feedback to the user ⬇️*

![Rubric06](photos/Rubric06.png)

*shows that day logged with the rest of the month being unlogged ⬇️*

![Rubric07](photos/Rubric07.png)

*shows how we used color number to represent moods-over-time in history tab and how the slider corresponds to the average mood over the respective sections span ⬇️* 

![Rubric08](photos/Rubric08.png)

*upon hitting new entry the current date is brought up which already has a good entry logged but it looks like this person rethought there mood and now are putting in a neutral entry to overide the previous entry ⬇️*

![Rubric09](photos/Rubric09.png)

*this is an example of the good entry looks upon pressing the mood button ⬇️*

![Rubric10](photos/Rubric10.png)

#### Newtonsoft.Json

We used this Nuget package to deserialize json information in our global variable class

*This code uses Newtonsoft.Json to deserialize the stored JSON string into a Dictionary<DateTime, Tuple<string, string>> object, which represents date statuses, retrieved from the application's preferences. ⬇️*

![Rubric11](photos/Rubric11.png)

*This code uses Newtonsoft.Json to serialize a dictionary containing date status data into a JSON string, which is then stored in the application's preferences. ⬇️*

![Rubric12](photos/Rubric12.png)

## Project Contributions
<!-- Describe each team member's contributions to the project -->
**Ben Hicks** - I worked on most of the backend of this project. so most of the button's functionality was implemented by me. Additionally, all of the mood data is set to a global variable and we used Xamarin.Essentials preferences to make it persist across sessions on each individual device

**Summer Gasaway** - I worked on most of the front-end design work, so how all the pages look and how all the buttons look were designed by me. Additionally, how each page links up to other pages throughout the application was all designed by me

## Rubric

*Project Submission - 160 points*
- [x] Complete project/solution submission - 160 points


*Documentation - 40 points*
- [x] [Project title](#moodcalendar) - 5 points
- [x] [Team member names](#team-members) - 5 points
- [x] [Project introduction](#moodcalendar) - 10 points
- [x] [Required skills](#required-skills) - 10 points
- [x] [Project contributions](#project-contributions) - 10 points
