   M S B A M L   `   `   `  ����I  EPIMTool.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PIMTool.Client.PresentationPIMTool.Client.Presentation  5   	   -    'PIMTool.Client.Presentation.ProjectView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:PIMTool.Client.Presentation     5   	     � Title$  Project detail��5	   	   $	��450��6    $	��800��6-   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   $��5q�6-   $��Id��68   �� 5   
   $��0��6   $��1��6   $��5q�6-   ��68   �� *	ProjectId+�� 5   
   $��1��6   $��0��6   $��5q�6-   $
��Name��68   �� 5   
   $��1��6   $��1��6   $��5q�6/   ��6:   �� *ProjectName+�� 5   
   $��2��6   $��0��6   $��5q�6-   $��Status��68   �� 5   
   $��2��6   $��1��6    $��5q�60    �� Text$ BindDataHere��6;   �� 5   
   $��3��6   $��0��6   $��5q�6-   $��
Start date��68   (  "System.Windows.Controls.DatePicker  5    
   $��3��6   $��1��6"   $��5q�62      SelectedDate$ 
01.01.2001X�6=   5!      5"      