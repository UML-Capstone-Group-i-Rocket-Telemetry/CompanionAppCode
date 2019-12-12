# CompanionAppCode
This repository contains the code for the companion app.
The companion app was written using visual studios. In this repository is the
entire visual studios project.

Inside CompanionAppCode/TelemetryCompanionApp/TelemetryCompanionApp are the code
files.

MainWindow.xaml contains the main window UI code.
  This includes the start button code and the UML logo code.

MainWindow.xaml.cs contains the main window functional code.
  This is just contains a function that navigates to the flight window when the
start button is pressed.

FlightWindow.xaml contains the flight page UI
  dataGrid contains column header information. This is used to put a header to
  the data from the excel sheet. Each column needs to get bound to the correct
  list of data from the TelemetryData Class in TelemetryData.cs. This is followed by a button that is clicked to select a flight file. Next are the three graphs. Labeled left, middle and rightGraph receptively. This is followed by comboBox which is the drop down selection menu for the refresh rate of the graphs. Then there are three comboBoxGraphs drop down selection boxes that allow selection of what data to display in each graph. Finally there are 4 textboxes that describe what each drop down menu is for

FlightWindow.xaml.cs contains the Flight Window's functional
  WindowFlight() initalizes the flight window and start a timer to keep track of
  refreshing.
  Then each of the charts are initialized as new series collections. Data will
  be binded to them after a drop down is selected and a refresh hits.
  DispatcherTimer_Tick() sets the refresh rate and rebinds the data at the
  specified interval.
  Rebind data assigns the data to graphs and table whenever it is called. Based
  on what the drop down selectors for the graphs say different data will be binded to the graphs.
  SetTimer() initalizes a new timer and returns that Timer.
  BTNOpenFile_Click() is the code that opens up file explorer so a flight file
  may be selected.
  ResetCharts() clears the data on the charts and is called before data is
  rebinded to them.

TelemetryData.cs contains the TelemetryData class
  This is a list object is bunch of lists that correspond to each measurement being taken from the CSV. The dataGrid object easy takes a list and displays it to a row in the table.
  ReadFile() will read in the CSV and parses each column into its respective element in TelemetryData.
