<h1>Blazor & Elastic Beanstalk Frontend</h1>

<p>We are using Blazor (which utilizes C# and HTML) to host an application via Elastic Beanstalk</p>

<p>#Documentation HTML files from DocFX can be found in the _site/api folder structure<p>

#Instructions:
If database has not been set up:
  1. Go to Add to DB page
    a) Upload appropriate file using the input file buttons as described on the page.
    The page has an input file button for the CSCI, CYBR, CIST, and MATH course lists
  2. Go to the Fetch Data page
    a) Make sure you have the web scraped files for the CSCI core requirements, and it is named Core.csv. 
    b) Make sure you have the web scraped files for the CSCI core extension requirements, and it is named Add.csv. 
    c) Make sure you have the web scraped files for the CSCI Upper Division requirements, and it is named Upper.csv.
    d) Make sure you have your class list with CourseName being the first line of the document, and it is named classList.csv
    e) Upload each of the files using the input button. This can be done separately, or all at once. If done separately, I would recommend that the class list be uploaded first, because the display is dependent on it. It shouldn't display anything until after classList has been uploaded first.

#Release Notes
<p>Currently our Blazor app can connect to the AWS SQL Server I have setup, locally, and grab information from the database tables I have provided.
The simple functionality I have put in the app is given a course name as a string in a text box, I will return the information for that course in an html table format.</p>

<p>Milestone 3<p>
<p>For Milestone 3 I added a page, that for now, looks up a specific local csv file in the application folder and uploads its contents into the appropriate database table. It uses a Blazor component that takes in a string as a parameter and uses that string to look up the table to add it to, and uses the string as the file name as well. It uses a switch statement, so that could use some refactoring.<p>
<p>I also updated the Fetch Data page for a simple display of using two lists of classes as input, grabbing two specific local files, so this doesn't yet work on the deployed version. It takes a list of required classes, and a list of classes someone has taken as input. It checks the list of required classes against the list of classes someone has taken and displays the list of required classes as h3 header elements with differing backgrounds. It shows a green background if you've taken the class, a yellow background if you meet the prerequisites to take it, and red if you do not meet all the prerequisites to take it. Additionally you can click on any of those headers and it will let you see the first level of prerequisites for that class, and follow the same format as above in the differing background color.<p>

<p>post milestone 3<p>
<p>I have converted all of the pages that were using file paths to instead use file inputs. On the database page there are 4 separate buttons to input a csv file into the database. They add the selected csv file to the appropriate database, given that the database does not contain that info already. On the Fetch Data page, you have one button that can take multiple files, but the naming structure of the files must match the following: classList.csv (for the user's list of taken classes), Add.csv (for the Additional Core Extension Classes), Upper.csv (for the upper division core extension courses), and Core.csv (for the Core requirements section). The page first loops through the selected files, and uploads the classList file, because that is used as input for the classes beforehand, and then it loops again and uploads the other files. <p>
  
<p>I have updated the visual display so that instead of colored backgrounds there are now colored boxes next to the classes, using the same coloring scheme as mentioned above. There is also a legend which explains what each colored box represents. The titles; Core requirements, Upper Division, and Core Extension are now background color coded to denote whether or not the class list provided meets the requirements that the CSCI course asks for, i.e. 12 credit hours for Upper Division, and 9 for Core Extension, and all classes taken for Core.<p>
