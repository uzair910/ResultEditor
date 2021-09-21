# ResultEditor
C# Desktop App assignment

**Introduction**

Your task is to create a functionally simple application which reads data and displays it on the screen.
This task gives you a small example of what we do here at Mapvision and also gives us an understanding 
of your software engineering practices for writing production-ready code.
We have provided you with Visual Studio C# solution to help you get started
• There is an example window which you can modify. You can also create your own windows or 
make your own application from scratch. Other languages can also be used.

**User story and requirements**

Parts are being manufactured on a production line. Mapvision Quality Gate measures every part that has 
been produced.
Quality engineer of the manufacturing line has results for one point from 20 parts. Each point has X, Y and 
Z coordinate values. Example data is shown below.


Measurement Axis Value

1 X 2061.43

1 Y -459.1

1 Z 378.72

2 X 2059.9

2 Y -499.7

2 Z 378.67

… … …


Create and application that helps the quality engineer analyze the results.
The quality engineer needs to find out the following with the software:
1. How much variation there is in the values for each axis?
2. Are there any exceptional values (outliers) that differ significantly from other values?
3. Do the values change over time (is there a trend, for example values are getting bigger)?
You can read the data from a file or use hard-coded data.


**Solution**


###################################################		General ###################################################

Executables can be run from either Debug or Release folder:
\ResultEditor\ResultStudio\bin\Debug\ResultStudio.exe
\ResultEditor\ResultStudio\bin\Release\ResultStudio.exe

I used test explorer to run the tests but NUnit Console could also be used.

###################################################		File paths ###################################################
The sample input files can be found in location:
ResultEditor\Library\Input

The input files I used for unit tests can be found under the location 
ResultEditor\UnitTests\TestData

###################################################		Code Walkthrough ###################################################

Views:
	ResultStudioForm
		There is main view where magic happens.
	StatsViewControl	
		There is one user control that is used to show statistics for individual axis.
	LogForm
		Shows information logged during the whole cycle in a popup dialog.
		
Controllers:	
	There are three controllers
		1) ParserController
				It reads data from input file and assigns a dictionary object, with values.
		2) VisualRepresentationController
				This is kind of a main controller that set almost all (99%) of the data that is shown in the UI
		3) ResultEditorController
			It is basically an intermediate layer the main view uses to interacts with ParserController. 
			Its objective is to fetch parsed data from ParserController and create an object from it that then the UI can use and understand.

COMMON:
	FilteredSeriesChartType
		This is a common method that is just used to limit the chart types that user can choose from. No hard rule applied into this. I picked the ones whose visual representation made most sense to me.
	
	Vecotr
		The axis value read from the data file for each part are stored in this object.

	AxisStatistics
		This is used by the custome user control, StatisticsViewControl.
		Purpose of this class is to keep track of all the statistical data for individual axis.
		It also performs computational like finding tolerance ranges, mean, min, max and variation values.
	

Unit Tests:
	ParserController_Tests
		Tests the method in ParserController.
		Tests file parsing. There are two test cases that test reading a file that exists and one that doesnot exists.
	
	VisualRepresentationControllerTests
		This tests a few methods from VisualRepresentationController that includes testing if charts are properly populated. And if the trend values are created correctly.
	
	AxistStatistics_Tests
		This class tests the methods in AxisStatistics class. It tests,against reference data, that for each axis the program correctly calculate min, max, variation, average values. 
