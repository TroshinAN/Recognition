   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  I ERecognitionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RecognitionWPF.ViewModelsRecognitionWPF.ViewModels -   'RecognitionWPF.Views.CamerasSettingView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  0vm'clr-namespace:RecognitionWPF.ViewModels    � Title$#  Настройка камер��$	��800�� � Icon$2 ,/RecognitionWPF;component/Images/Setting.png�� � 
ResizeMode$ NoResize=� � SizeToContent$ Height=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ ThreeDBorderWindow=� � DataContext 7  1RecognitionWPF.ViewModels.CamerasSettingViewModel   � 	Resources  �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value   BorderGroups0  *RecognitionWPF.ViewModels.MultyBoolConvert  MultyBoolConvert��%i  '��       '�� �     &	  �     &	 <    �� " ��.��� 	 � ��
 Z� �� 	 � ��
 Z� �� 	 � ��$
 40���� 	 � ��$
 40���� 	 � ��$

 10,5q� P�  � �� . . ��� 	 � ��$
 3q��� " ��.��� 	 � ��$
 5q��� " ��.��� 	 � ��

 ������� 	 � ��$
 2q��� 	 �@��Padding$
 40q��� 	 � ��$
 0q�  .��� -    �Name$ MainGrid��
����İ� � RowDefinitions �� $
��auto ��� $��* �.+��� $
��Left=����� *SaveAndExit+.���� $6��0/RecognitionWPF;component/Images/SaveAndExit.png��.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ Click��.   (System.Windows.Interactivity.TriggerBase   Actions. >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ Close��   TargetObject ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL�� $��1�� �� $
��auto ��� $��* �.+�� -   $ MainParameters��$
��20,0q� �� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+��� -    ��Name$ CheckedMainPort��$��3��$
��Left=�$F��@Использовать единый порт для камер�� d� 	IsChecked �� *IsUsedMainPort+�� $��3��{���  �� ElementName$ CheckedMainPort�� �� Path$ 	IsChecked����� *
MainPort+�� -   $ CheckedMainLogin��$��1��$��3��$
��Left=�$]��WИспользовать единое имя пользователя для камер�� �� *IsUsedMainLogin+�� $��1��$��3��{��� $ CheckedMainLogin��$ 	IsChecked����� *	MainLogin+�� -   $ CheckedMainPassword��$��2��$��3��$
��Left=�$J��DИспользовать единый пароль для камер�� �� *IsUsedMainPassword+�� $��2��$��3��{��� $ CheckedMainPassword��$ 	IsChecked����� *MainPassword+� -   $ SingleParameters��$��1��$��20,20q� �� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��4��#��[  �� -   $ CheckedCamera1��$��4��$��-8q�$
��Left=�$	��Top=� �� *Camera1IsChecked+.���� $��-5q�
����İ�.��Камера 1�� $��10q�$
��Left=�$��Center=� �� Orientation$ Vertical=�.+��� .��(&IP адрес/Доменное имя:�� .��	Порт:�� $��1��$��Center=�.+��� {��� $ CheckedCamera1��$ 	IsChecked����� *Camera1Address+�� ���� *Camera1Port+.��{�`�  `� 	Converter# [ .1��� $ CheckedCamera1��$ 	IsChecked��� $ CheckedMainPort��$ 	IsChecked�.���� $��2��$
��10,0q�$
��Left=�$��Center=�$ Vertical=�.+��� .��" Имя пользователя:�� .��Пароль:�� $��3��$��Center=�.+��� ���� *Camera1Login+.��{�`� # [ .1��� $ CheckedCamera1��$ 	IsChecked��� $ CheckedMainLogin��$ 	IsChecked�.���� ���� *Camera1Password+.��{�`� # [ .1��� $ CheckedCamera1��$ 	IsChecked��� $ CheckedMainPassword��$ 	IsChecked�.���� $��1��$��4��#��[  �� -   $ CheckedCamera2��$��1��$��4��$��-8q�$
��Left=�$	��Top=� �� *Camera2IsChecked+.���� $��-5q�
����İ�.��Камера 2�� $��1��$
��10,0q�$
��Left=�$��Center=�$ Vertical=�.+��� .��(&IP адрес/Доменное имя:�� .��	Порт:�� $��1��$��1��$��Center=�.+��� {��� $ CheckedCamera2��$ 	IsChecked����� *Camera2Address+�� ���� *Camera2Port+.��{�`� # [ .1��� $ CheckedCamera2��$ 	IsChecked��� $ CheckedMainPort��$ 	IsChecked�.���� $��1��$��2��$
��10,0q�$
��Left=�$��Center=�$ Vertical=�.+��� .��" Имя пользователя:�� .��Пароль:�� $��1��$��3��$��Center=�.+��� ���� *Camera2Login+.��{�`� # [ .1��� $ CheckedCamera2��$ 	IsChecked��� $ CheckedMainLogin��$ 	IsChecked�.���� ���� *Camera2Password+.��{�`� # [ .1��� $ CheckedCamera2��$ 	IsChecked��� $ CheckedMainPassword��$ 	IsChecked�.���� $��2��$��4��#��[  �� -	   $ CheckedCamera3��$��2��$��4��$��-8q�$
��Left=�$	��Top=� �� *Camera3IsChecked+.���� $��-5q�
����İ�.��Камера 3�� $��2��$
��10,0q�$
��Left=�$��Center=�$ Vertical=�.+��� .��(&IP адрес/Доменное имя:�� .��	Порт:�� $��2��$��1��$��Center=�.+��� {��� $ CheckedCamera3��$ 	IsChecked����� *Camera3Address+�� ���� *Camera3Port+.��{�`� # [ .1��� $ CheckedCamera3��$ 	IsChecked��� $ CheckedMainPort��$ 	IsChecked�.���� $��2��$��2��$
��10,0q�$
��Left=�$��Center=�$ Vertical=�.+��� .��" Имя пользователя:�� .��Пароль:�� $��2��$��3��$��Center=�.+��� ���� *Camera3Login+.��{�`� # [ .1��� $ CheckedCamera3��$ 	IsChecked��� $ CheckedMainLogin��$ 	IsChecked�.���� ���� *Camera3Password+.��{�`� # [ .1��� $ CheckedCamera3��$ 	IsChecked��� $ CheckedMainPassword��$ 	IsChecked�.���� $��3��$��4��#��[  �� -
   $ CheckedCamera4��$��3��$��4��$��-8q�$
��Left=�$	��Top=� �� *Camera4IsChecked+.���� $��-5q�
����İ�.��Камера 4�� $��3��$
��10,0q�$
��Left=�$��Center=�$ Vertical=�.+��� .��(&IP адрес/Доменное имя:�� .��	Порт:�� $��3��$��1��$��Center=�.+��� {��� $ CheckedCamera4��$ 	IsChecked����� *Camera4Address+�� ���� *Camera4Port+.��{�`� # [ .1��� $ CheckedCamera4��$ 	IsChecked��� $ CheckedMainPort��$ 	IsChecked�.���� $��3��$��2��$
��10,0q�$
��Left=�$��Center=�$ Vertical=�.+��� .��" Имя пользователя:�� .��Пароль:�� $��3��$��3��$��Center=�.+��� ���� *Camera4Login+.��{�`� # [ .1��� $ CheckedCamera4��$ 	IsChecked��� $ CheckedMainLogin��$ 	IsChecked�.���� ���� *Camera4Password+.��{�`� # [ .1��� $ CheckedCamera4��$ 	IsChecked��� $ CheckedMainPassword��$ 	IsChecked�.��