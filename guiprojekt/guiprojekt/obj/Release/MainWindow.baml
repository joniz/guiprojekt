   M S B A M L   `   `   `  ���� E  Aguiprojekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:guiprojekt
guiprojekt      guiprojekt.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:guiprojekt     -     � Title$  
MainWindow��$	��450��$	��550��   CustomWindow#���    � 	Resources  �� 
TargetType �� Property �� Value  måndagStyle �� Triggers P� Property P� Value �� 
TargetType  tisdagStyle  onsdagStyle  torsdagStyle  fredagStyle  lördagStyle  söndagStyle  läggTillPåminnelseStyle3  -System.Windows.Media.Effects.DropShadowEffect	   Color
   Opacity J� Opacity��%  &	        &	 7     &	 #    &	     &	 �    &	 �    &	 �    &	 �    &	 �    �� " �.���  �@�
ResizeMode$ CanMinimize=��� " �� P� måndag�� � {� . . ���  � �� �� " ��.R��� $$��/Resources/Images/måndag6.png��P�  � �� . . ���  � �� �� .R��� $*��$/Resources/Images/måndagPushed6.png��$	��102��$��72���� " �� P� 
tisdag�� � {� . . ���  � �� �� " ��.R��� $#��/Resources/Images/tisdag6.png��P�  � �� . . ���  � �� �� .R��� $)��#/Resources/Images/tisdagPushed6.png��$	��102��$��72���� " �� P� 
onsdag�� � {� . . ���  � �� �� " ��.R��� $#��/Resources/Images/onsdag6.png��P�  � �� . . ���  � �� �� .R��� $)��#/Resources/Images/onsdagPushed6.png��$	��102��$��72���� " �� P� torsdag�� � {� . . ���  � �� �� " ��.R��� $$��/Resources/Images/torsdag6.png��P�  � �� . . ���  � �� �� .R��� $*��$/Resources/Images/torsdagPushed6.png��$	��102��$��72���� " �� P� 
fredag�� � {� . . ���  � �� �� " ��.R��� $#��/Resources/Images/fredag6.png��P�  � �� . . ���  � �� �� .R��� $)��#/Resources/Images/fredagPushed6.png��$	��102��$��72���� " �� P� lördag�� � {� . . ���  � �� �� " ��.R��� $$��/Resources/Images/lördag6.png��P�  � �� . . ���  � �� �� .R��� $*��$/Resources/Images/lördagPushed6.png��$	��102��$��72���� " �� P� söndag�� � {� . . ���  � �� �� " ��.R��� $$��/Resources/Images/söndag6.png��P�  � �� . . ���  � �� �� .R��� $*��$/Resources/Images/söndagPushed6.png��$	��102��$��72���� " �� P� läggTillPåminnelse�� � {� . . ���  � �� �� " ��.R��� $ ��/Resources/Images/plus.png����  �@J�Effect   $	 Black��$	
 0.4Q�P�  � �� . . ���  � �� �� .R��� $ ��/Resources/Images/plus.png��$	 0.7Q�.��� 
����ح� � RowDefinitions �� $��80 ���  � ColumnDefinitions �� $	��110 ��� .+��� -   $��header��$��Daily Reminder��$��Rockwell Extra Bold)�
�������$��50(�$��2��$��Center=�$��Italic$�$��0,0,0.333,0q�����  �� ImageSource$" /Resources/Images/header.png��A� -   $��	pickMonth�� A� Rows$ 8��$��1��$��0��$��2��
������ .+��� -   $��monday�� � Cursor$
 Hand��#���  
��������� -   $��tuesday��$
 Hand��#���  
��������� -   $��	wednesday��$
 Hand��#���  
��������� -   $��thursday��$
 Hand��#���  
��������� -   $��friday��$
 Hand��#���  
��������� -	   $��saturday��$
 Hand��#���  
��������� -
   $��sunday��$
 Hand��#���  
��������� -   $��reminder��$
 Hand��#���  
��������� -   $��newReminder��$��1��$��1��$y�	Collapsed=�.+�   guiprojekt.addReminder  �� -   $��showEditReminder��$��1��$��1��$y�	Collapsed=�.+�   guiprojekt.EditReminder  -     Name$ editReminder���� -   $��
scrollBar1��$
��Auto=�$��1��$��1��.��� $��1��$��1��.+��� -   $��
infoMonday�� �� Orientation$ Vertical=�$��1��$��1��$y�Hidden=��� -   $��
scrollBar2��$
��Auto=�$��1��$��1��.��� $��1��$��1��.+��� -   $��infoTuesday��$ Vertical=�$��1��$��1��$y�Hidden=��� -   $��
scrollBar3��$
��Auto=�$��1��$��1��.��� $��1��$��1��.+��� -   $��infoWednesday��$ Vertical=�$��1��$��1��$y�Hidden=��� -   $��
scrollBar4��$
��Auto=�$��1��$��1��.��� $��1��$��1��.+��� -   $��infoThursday��$ Vertical=�$��1��$��1��$y�Hidden=��� -   $��
scrollBar5��$
��Auto=�$��1��$��1��.��� $��1��$��1��.+��� -   $��
infoFriday��$ Vertical=�$��1��$��1��$y�Hidden=��� -   $��
scrollBar6��$
��Auto=�$��1��$��1��.��� $��1��$��1��.+��� -   $��infoSaturday��$ Vertical=�$��1��$��1��$y�Hidden=��� -   $��
scrollBar7��$
��Auto=�$��1��$��1��.��� $��1��$��1��.+��� -   $��
infoSunday��$ Vertical=�$��1��$��1��$y�Hidden=�