   M S B A M L   `   `   `  ����H  DPayrollSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PayrollSystemPayrollSystem  5   	       PayrollSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PayrollSystem     5   	     � Title$  Oasis Payroll System��5   	   $��362.8��6&   $	��525��65   
�������
���   �.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      �� 5      $��0* �6   .+�5   
   �� $��1q�6   $��3��6%   $��0,254,0.4,-0.4q�69   $	��Top=�6Q   $	��518��6i   ���	#FF999999$��80��6�   �� 5   
   -   5         ��Name$ txtUserName��5      $��3��6'   $
��Left=�6;   $��23��6V   $��176,114,0,0q�6b    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��275��6�   6�   �� 5   
   $��3��6   $��Enter Username:��6$   $
��Left=�6>   $��
75,112,0,0q�6Y   $	��Top=�6m    J� RenderTransformOrigin$ 0.517,0.422&�6�   �� 5   
   $��3��6   $��Enter Password:��6$   $
��Left=�6>   $��
78,141,0,0q�6Y   $	��Top=�6m   �� 5   
   $��3��6   $
��Left=�6$   $��189,265,0,0q�6?   $	��Top=�6T   .��5      �� $��Dont Have an Account?��6   5      �� 5   
   -   5         ��Name$ lblCreateUser��5      $��10q�6'   $��3��64   $��CREATE ONE HERE��6H   $
��Left=�6b   $��189,281,0,0q�6}   $	��Top=�6�   $
��Bold"�6�   $��14(�6�   ���	#FF2A69AE � Cursor$
 Hand��6�   $��38��6�   6�   �� 5   
   $��3��6   $%��WELCOME TO OASIS PAYROLL SYSTEM��6$   $��135,29,19.4,0q�6N   $	��Top=�6e   $	��364��6}   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   $��Malgun Gothic)�6�   $��18(�6�   ���	#FF29ABE26  G� 5   
   -   5         G�Name$ txtPassword��5      $��3��6+   $
��Left=�6?   $��176,144,0,0q�6Z   $	��Top=�6o   $	��275��6�   $��23��6�   �� 5   
   -   5         ��Name$ btnLogin��5      $��3��6#   $��LOGIN ��67   $
��Left=�5      $��176,181,0,0q�6   $	��Top=�63   $	��275��6K   $��34��6W   
����������	#FF2A69AE$
��Bold"�6�   $��14(�6�   ���	#FF435F7F6�   �� 5   
   $��3��6   $
��Left=�6$   $��72��6?   $��	10,10,0,0q�6K   $	��Top=�6^   $	��112��6v   $��Resources/MainLogo.jpg��6�   $
��Fill=�6�   5      5       