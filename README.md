# Pick-a-planet-Star-Wars

## Goal
The goal of this is to create a simple quiz type object using a database of Star Wars planets to match responses to corresponding planets.  The user will answer a question about population, surface water% and pick from a list three biomes of interest. Once this is complete the program will compile and sort the planets, displaying to them the top 5 planets in terms of number of matches to their indicated preferences. The user also has the ability to display all scores to see the full list.

## Other Functionality
The user can add, edit, or delete planets. The program also has superlative features which currently display the most and least populous planets. There is also an option to display the entire list of planets with relevent information.

## Design Choice
Since the user can add, edit, or delete planets, every time a new main menu method is called, it re-reads the entire file to ensure the edits can be seen on the users next selection.

Because of some difficulty reading the file with commas inside the values themselves, a CSV reader class was implemented from a stackoverflow forum page at : https://stackoverflow.com/questions/21342949/how-can-i-split-a-string-while-ignore-commas-in-between-quotes

I kept as much out of the main method as possible and grouped as many relevant methods within classes as possible. When I could, I removed repetitive code and created new methods and called those methods when the code was needed.

I used if statements to call the main menu methods rather than putting the code within the if statements to ensure if I wanted to put additonal functionality within the code to to call the methods again in some other capacity, it would not rely on user input.
