   M S B A M L   `   `   `  ����H  DPayrollSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PayrollSystemPayrollSystem  5   	       PayrollSystem.MainUI   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PayrollSystem     5   	   -   5          � Title$  Oasis Payroll System��5   	   $	��776��6&   $	��790��63    � WindowStyle$ ThreeDBorderWindow=�6V   
�������.��5	      � .+�5
   
   �� $
��Left=�6   $��42��6/   $��	0,698,0,0q�6;   ���	#FFB0B0B0$	��Top=�6a   $	��784��6y   �� 5   
   -   5         ��Name$ 
lblWelcome��5      $��Welome: ��6$   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $	��353��6}   $��Malgun Gothic)�6�   $��16(�6�   ���	#FF4646466�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGEmployees��5      $
��Left=�6(   $	��185��6C   $��
10,118,0,0q�6P   $	��Top=�6d   $	��751��6|      
IsReadOnly . 
�������6�   �� 5   
   -   5         ��Name$ addUpdateEmployee��5      $��ADD/UPDATE Employee��6,   $
��Left=�6J   $��
10,315,0,0q�6e   $	��Top=�6y   $	��247��6�   $��39��6�   ���	#FF29ABE2$��14(�6�   $
��Bold"�6�   $��Malgun Gothic)�6   
����������	#FF2A69AE6.  �� 5   
   -   5        $ deleteEmployee��5      $��DELETE EMPLOYEE��6)   $
��Left=�6C   $��268,315,0,0q�6^   $	��Top=�6s   $	��131��6�   $��39��6�   $��Malgun Gothic)�6�   $
��Bold"�6�   ���	#FF29ABE2
����������	#FF2A69AE6  �� 5   
   -   5         ��Name$ txtHoursWorked��5      $
��Left=�6*   $��23��6E   $��413,331,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $��94��6�   6�   �� 5   
   -   5         ��Name$ cbSickLeave��5      $
��Left=�6(   $��525,331,0,0q�6C   $	��Top=�6X   $	��101��6p   ���	#FF29ABE2���	#FF0081B76�   �� 5   
   -   5        $ cbAnnualLeave��5      $
��Left=�6*   $��644,332,0,0q�6E   $	��Top=�6Z   $	��116��6r   ���	#FF29ABE2���	#FF0081B7��5      �� 5      	 �� EndPoint$		 0,1&�6&   
 �� 
StartPoint$	
 0,0&�65   .��5      �  � Color$ 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5      $ 	#FFE5E5E5��6#   $ 1Q�65   5      5      �� 5   
   $��HOURS WORKED:��6   $
��Left=�6(   $��408,308,0,0q�6C   $	��Top=�6X    J� RenderTransformOrigin$ 0.288,0.115&�6p   $	��145��6�   $��25��6�   ���	#FF29ABE2$��Malgun Gothic)�6�   $
��Bold"�6�   $��11(�6�   �� 5   
   $��SICK LEAVE:��6   $
��Left=�6&   $��519,308,0,0q�6A   $	��Top=�6V   ���	#FF29ABE2$��Malgun Gothic)�6�   $
��Bold"�6�   �� 5   
   $��ANNUAL LEAVE:��6   $
��Left=�6(   $��641,308,0,0q�6C   $	��Top=�6X   ���	#FF29ABE2$��Malgun Gothic)�6�   $
��Bold"�6�   �� 5   
   -	   5         ��Name$ 	tbEmpInfo��5      $
��Left=�6'   $��
10,376,0,0q�6B   $
��Wrap=�6V   $��  Employee Information��6j   $	��Top=�6�   $	��226��6�   $	��389��6�   ���	#FFF8FBFF$��Malgun Gothic)�6�   $
��Bold"�6�   ���	#FF4B4B4B��6�   Z� 6  �� 5   
   -
   5        $ tbResult��5      $
��Left=�6&   $��408,376,0,0q�6A   $
��Wrap=�6V   $��  Payment Information��6j   $	��Top=�6�   $	��293��6�   $	��352��6�   ���	#FFF8FBFF$��Malgun Gothic)�6�   $
��Bold"�6�   ���	#FF4B4B4B��6�   Z� 6  �� 5   
   -   5        $ btnPay��5      $��PAY EMPLOYEE ��6!   $
��Left=�69   $��
10,612,0,0q�6T   $	��Top=�6h   $	��145��6�   $��57��6�   ���	#FF29ABE2$��Malgun Gothic)�6�   $��14(�6�   $
��Bold"�6�   
����������	#FF2A69AE6  �� 5    
   -   5        $ 
btnPayslip��5       $��GENERATE PAYSLIP��6%   $
��Left=�6@   $��173,612,0,0q�6[   $	��Top=�6p   $	��226��6�   $��57��6�   ���	#FF29ABE2$��Malgun Gothic)�6�   $��14(�6�   $
��Bold"�6�   
����������	#FF2A69AE6  �� 5!   
   $
��Left=�6   $	��103��6+   $��
598,10,0,0q�68   $	��Top=�6L   $	��178��6d   $
��Fill=�6p   $��Resources/MainLogo.jpg��6   �� 5"   
   $/��)OASIS PAYROLL SYSTEM - Choose An Employee��6   $��10,84,385,0q�6D   $	��Top=�6Y   $	��389��6q   $��Center=�6}   $��Center=�6�   $
��Bold"�6�   $��Malgun Gothic)�6�   $��16(�6�   ���	#FF29ABE2$��34��6  $ 0.492,0.462&�6  �� 5#   
   -   5        $ lblWelcome_Copy��5#      $?��9© Copyright | All Rights Reserved | Oasis Payroll System��6)   $
��Left=�6l   $��
10,705,0,0q�6�   $	��Top=�6�   $	��433��6�   $��Malgun Gothic)�6�   $��10(�6�   ���	#FF4646466�   5%      5&      