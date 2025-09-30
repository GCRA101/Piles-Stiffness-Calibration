# Description

The Piles Stiffness Calibration Tool is a CSI ETABS Plugin developed by Buro Happold to assist structural and geotechnical engineers to automate the calibration of existing/proposed piles stiffnesses under existing/proposed loads.

The tool is directly accessible in the ETABS UI and allows to run in parallel alternate analyses both in ETABS (structural software) and in Oasys PDisp (geotechnical software): the first to compute the structural loads applied onto the piles and the second to determine their stiffness.

The process continues until the convergence criteria are met and the documentation on the outputs is produced automatically for the engineers.

<img width="965" height="552" alt="image" src="https://github.com/user-attachments/assets/a69a8c98-f1d6-4fef-a7a3-31965f757eaf" />

# Installation
The process of installation of the plugin is quite immediate and can be summarized in the following steps.

1.	Open ETABS and create a new model
2.	Left Click on “Tools”->”Add/Show Plugins”. The “External Plugin Data” window pops up.

<img width="795" height="245" alt="image" src="https://github.com/user-attachments/assets/f6f2a068-d3d8-42b3-b06e-f3fa4cd266e7" />

3.	In the “External Plugin Data” Window, left click on the “Browse” button and select the assembly Piles_Stiffness_Calibration.dll file.

<img width="794" height="285" alt="image" src="https://github.com/user-attachments/assets/2432c5fb-d0cb-4feb-aa50-8fd5e1cb1183" />

<img width="794" height="297" alt="image" src="https://github.com/user-attachments/assets/ce26f581-4f8a-4c88-be36-aeaad93cea9b" />

4.	Back in the “External Plugin Data” Window, the Name, Menu Text and path of the plugin will now be displayed in the corresponding textboxes. Left click on the “Add” button to load the selected plugin into ETABS.

<img width="798" height="286" alt="image" src="https://github.com/user-attachments/assets/03359ef8-cb6b-41ec-a191-7904ea25d540" />

5.	Left click on the “OK” button and all is done. Now, when getting back into the “Tools” ribbon button, it will be possible to see the uploaded plugin available for use. Just click on it to run it whenever you want and in whatever future session of ETABS.

 <img width="803" height="252" alt="image" src="https://github.com/user-attachments/assets/a4e9c6d6-d9e1-414b-94d8-8efbb6f90b1b" />




# User Interface
## ETABS Tools UI
In order to run the Plugin, it’s just enough to access the Tools Menu in ETABS and left click on the name of the plugin in the drop-down window coming up.

<img width="803" height="252" alt="image" src="https://github.com/user-attachments/assets/c82b22e9-fcfe-4bc5-b8fa-9ba36198478c" />
Figure 2: Access to the Tool via the ETABS UI

## SplashScreen
As soon as the Plugin starts running, a Splashscreen window will appear on the screen.
This contains the logo of the tool, the name, the version and the copyright.
After few seconds it will disappear leaving space to the AboutBox window.

<img width="559" height="345" alt="image" src="https://github.com/user-attachments/assets/5317b0f4-3ec5-4051-902d-3f3d1547b47c" />
Figure 3: Tool's Splashscreen Window

## AboutBox
The AboutBox window is a very important part of the tool’s UI as it contains relevant information about the use of the plugin. In addition to the logo and the versioning/copyright information, it contains a textbox where the strengths and limitations of the tool are reported and regularly updated.
It is strongly recommended that, whenever a new version of the tool gets released, the user takes the chance to read all this information before moving on using the tool.
The information reported is subdivided in the following sections:
•	DESCRIPTION
o	High level description of the scope of the tool.
•	ALGORITHM
o	Step-by-step process followed by the tool to compute the outputs.
•	UI FEATURES
o	List of main inputs to be collected from the user via the User Interface
•	LIMITATIONS
o	Current limitations the user has to be aware of before using the tool.

Once finished reading, left click on the “OK” button in the bottom right corner of the window to move on to the Inputs Form.

<img width="535" height="458" alt="image" src="https://github.com/user-attachments/assets/09f7f7e0-6625-4e0d-b5d5-2bc44dcaa739" /> 
Figure 4: Tool's AboutBox Window


## Inputs Form
The Inputs Form is the main window of the tool. It’s the window that reads data from the ETABS model currently running, allows the user to select the inputs required, runs the iterative process and informs the user when the process finishes.

The Form is designed to be as simple as possible and is subdivided into 3 main sections:
•	The Inputs Section
o	Subdivided into “ETABS Inputs” and “PDisp Inputs” groups.
•	The Run Iteration Button
o	To be clicked when the user is ready to launch the iteration.
•	The Progress Bar
o	Filling gradually while the iteration is running up to completion.

A detailed description of both Inputs and Outputs is reported in the following paragraphs of this document.

<img width="292" height="653" alt="image" src="https://github.com/user-attachments/assets/8731dea4-e17a-4571-ab0f-4096a44a108d" />
Figure 5: Tool's Inputs Form Window



# Inputs
## ETABS Inputs
The inputs that the tool requires the user to choose/select are the following ones:
•	Groups
•	Load Combos
•	Piles Stiffness Boundary Condition

### Groups
The Groups appearing within this List-Box (see Figure 5) are directly extracted by the tool from the ETABS model currently running.
These groups have to be set up by the user in the ETABS model prior to running the tool.
It is important that all the nodes representing piles in the ETABS model are assigned with a specific group (e.g. “Piles”).
The tool is designed to select the pile nodes based on the group selected by the user.

### Load Combinations
The Load Combinations displayed in this List-Box (see Figure 5) are directly extracted by the tool from the ETABS model currently running.
Similarly to what happens with the Groups, the user is requested to select one single Load Combination.
The Load Combination is the one that is used by the tool to compute the pile loads in ETABS and then determine the corresponding pile stiffnesses in PDisp.

### Piles Stiffness Boundary Condition
The piles stiffness boundary condition stands for the initial value of the stiffness of the piles that the iteration will start running from.
Three different options are available:
•	All Rigid Supports
•	All Same Stiffness [KN/mm]
•	Import from Serialized File

#### All Rigid Supports
This is the most basic and probably most frequent option to be used.
All the pile supports will be initially set as rigid pinned supports. 

This can be possibly the best choice when no data nor estimate about the stiffness of the piles is currently available.
Therefore, the pile loads computed by ETABS in the first iteration of the process will be determined assuming all the piles to have the same infinite stiffness. 

Moving to the following iterations, the pile supports will be assigned by the tool with specific stiffness values that will be calculated in the PDisp model that is running in parallel.

#### All Same Stiffness [KN/mm]
This is the intermediate option and consists in assigning to all the piles the same vertical stiffness value expressed in KN/mm.

This option is to be used when, for example, the geotechnical engineers can calculate an initial estimate of the stiffness value for all the piles.

This represents a good starting point (more refined and accurate compared to the “All Rigid Supports” assumption) for running the iterative calibration of the piles stiffnesses.

#### Import from Serialized File
This is the most advanced option and it is especially useful when designing new structures on top of existing piles.

In such case, the existing piles will have already experienced a certain amount of load due to the pre-existing structure being supported on them. 
Therefore, in the moment when the existing building gets demolished allowing for constructing the new one, the piles will have reached a certain value of stiffness that can increase only if the new proposed loads applied onto them are higher than the ones from the existing scenario (as long as the piles don’t fail).

This means that, prior to running the piles stiffness calibration on the proposed model, we need to have run it on the existing (to be demolished) model. This will allow to get the converged stiffness value for all the existing piles as well as the information regarding the maximum load they have been subjected to during the life of the existing building.
This will be the starting point for the analysis of the proposed scenario (whenever, in fact, an existing pile is subjected to a proposed load lower than the existing one, the pile won’t settle. The tool will then assign to the pile a rigid support that will re-create the absence of vertical settlement at that specific location).

All this information is stored within a .json file that is produced by the tool itself at the end of the calibration of the existing model.
Loading this .json file, the tool will be able to read all the data calculated for all the existing piles, apply them to the piles in the proposed model and then start the calibration process from this start point (piles in the existing and in the proposed model will have to be assigned with the same names).

## PDisp Inputs

The inputs that the tool requires the user to choose/select are the following ones:
•	PDisp File
•	Maximum Displacement Variation
•	Maximum Number of Analysis Iterations


### PDisp File
The user is requested to select the Oasys PDisp file that will be run by the tool in parallel with the ETABS model of the building (see Figure 5). 
It is strongly recommended that the Oasys PDisp model is set up by the geotechnical engineers working on the project.
Geotechnical and structural engineers will have anyway to work together to make sure that all the pile nodes modelled in the PDisp file are assigned with the same name as the corresponding ones present in the ETABS model.
The Tool needs in fact to match the pile nodes in the two software packages in order to be able to transfer loads/stiffnesses from one to the other iteratively. The matching of the piles is not achieved based on the location of the pile nodes but based on their names.
Before running the tool, it’s important that the matching of the names of all pile nodes in the two software packages is checked carefully.


<img width="701" height="432" alt="image" src="https://github.com/user-attachments/assets/a8057492-c2d5-43a2-9346-137fdea3cb1d" />
Figure 6: PDisp Model: 3D View (left), Pile Points List (right)


### Max Disp Variation
Together with the maximum number of analysis iterations, this is one of the convergence criteria for the calibration of the piles stiffnesses (see Figure 5). 
The value is defined as a pre-defined percentage (i.e. 5%, 10%, 15% or 20%).
Assuming that the value of 5% is chosen, that means that the iterative calibration process run by the tool will continue until the increase/decrease of stiffness/displacement from one iteration to the other is smaller than 5% on all piles.
That means that we’ve reached the convergence of our analysis and, therefore, it can be stopped.
Whatever convergence criterion gets reached first between this one and the other, the tool will stop the iterative process and will output the results reached at that stage.


### Max Num of Analysis Iterations
Together with the maximum displacement variation, this is one of the convergence criteria for the calibration of the piles stiffnesses (see Figure 5).
The maximum number of iterations the tool can run can be chosen from the following pre-set list: 2, 3, 4, 5, 10, 20, 50, 100.
Whatever convergence criterion gets reached first between this one and the other, the tool will stop the iterative process and will output the results reached at that stage.


## Outputs
Data set serialized in JSON
The main output of the tool is a list of data sets, serialized in json, containing all the results of each iteration.
For each iteration, up to the last one, the corresponding data set consists essentially in a list of records (one for each pile object) that contains all the relevant identifying information (name, location, diameter, length…) as well as analysis outputs (loads, displacements, stiffnesses) relevant for that pile.

Serializing this information in JSON allows to minimize the size of the output (thus allowing to use the tool on models of significant size without the risk of producing heavy output files) as well as maximize its readability making it retrievable in the widest range of software packages possible.

<img width="489" height="372" alt="image" src="https://github.com/user-attachments/assets/23b77626-4439-4ca8-9908-8cb469a944b9" />
Figure 7: Sample of JSON File Content

For instance, once the JSON file has been produced by the tool, it is possible to visualize the outputs graphically in Rhino via Grasshopper just simply using a specific C# gh component de-serializing json files.
The C# component and a sample script showing how to do it are saved at the following link [GH Template Files]

<img width="686" height="375" alt="image" src="https://github.com/user-attachments/assets/6f08a796-4ae2-4ca5-9daa-cbbdf966d1f9" />
Figure 8: C# Component for deserializing the output JSON File and Data Extraction in Grasshopper
The data imported in the Grasshopper environment can then be visualized, manipulated and be used in whatever computational workflow the user might need.

<img width="1004" height="265" alt="image" src="https://github.com/user-attachments/assets/f9e61a6d-5e50-479f-9f67-c31b4902aec5" />
Figure 9: 3D Visualization of the outputs in the Rhino Environment via Grasshopper

Summary Excel Spreadsheet
In addition to the json file and the possibility of reading it in grasshopper, also an excel spreadsheet is produced containing all the relevant outputs computed by the tool.
The excel spreadsheet is built by the tool automatically reading the json data sets behind the scenes and reporting them in excel tables and bar charts properly formatted. 
In this way, the user has got the chance to have immediately a full report of the outputs and of the trend of the iterationa step-by-step in a simple and universally readable format.


<img width="1004" height="456" alt="image" src="https://github.com/user-attachments/assets/7c2c6d66-1c24-4563-8528-8d37da6c3816" />
Figure 10: Pile Calibration Outputs in Excel: Table (above) and Bar Charts (below)

ETABS and PDisp Models
In order to allow both the structural and the geotechnical engineers to have a full track of records of all the steps the tool has gone through during the iteration, the tool is designed to save automatically and store all the ETABS and PDisp models created during the process.
For each iteration, the corresponding ETABS and PDisp models used are saved with a proper label with a unique reference to the iteration number they correspond to. 
No models overwriting occurs and all files are saved so that the engineers can time-travel through the iteration steps, thus allowing for maximum openness and reliability.

<img width="537" height="402" alt="image" src="https://github.com/user-attachments/assets/3e6799ee-b623-4ea1-85f3-047d598db1c1" />
Figure 11: Output Models and JSON Files for each Iteration
