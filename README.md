# TwinCAT-ADS-MC

motivation: 
need to be able to change/send motion parameters and commands over ADS. 
this is proof of concept code that communicates the same way as IBEX, demonstrating that motion parameters can be changed. 
also demonstrating rough framework of communication procedure, both on user (IBEX) side and Beckhoff runtime side.
this code utilises a new method of ADS communication (InvokeRpcMethod) that will improve both IBEX and Beckhoff codebases by simplifying communication code.

c# code runs the GUI.
TwinCAT 3 solution in the XAE folder describes the HMI as well as the methods for performing motion commands.

key features:
- GUI allowing the user to send motion commands to a Beckhoff PLC (or local runtime) over ADS
- also allows the user to edit the axis parameters
- gives real time feedback of current values & parameters
- independent control of 4 axes
- can connect to any local machine beckhoff runtime or to Beckhoff PLC that is connected to the network
- save and load axis/loop setup parameters to a file

editable motion parameters:
- axis maximum velocities, acceleration, jerk
- jog increments
- encoder scalings
- encoder control loop (change between encoders)
- encoder maximum value
- encoder inverted polarity
- drive inverted polarity
- controller PID parameters
and others