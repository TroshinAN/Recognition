   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  I ERecognitionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RecognitionWPF.ViewModelsRecognitionWPF.ViewModels 2   ,RecognitionWPF.Views.RecongnitionSettingView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  0vm'clr-namespace:RecognitionWPF.ViewModels    � Title$H  BНастройка устройства распознавания��$	��800�� � Icon$2 ,/RecognitionWPF;component/Images/Setting.png�� � 
ResizeMode$ NoResize=� � SizeToContent$ Height=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ ThreeDBorderWindow=� � DataContext ;  5RecognitionWPF.ViewModels.RecognitionSettingViewModel   � 	Resources  �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value   BorderGroups  LabelBorderName0  *RecognitionWPF.ViewModels.MultyBoolConvert  MultyBoolConvert��%�  '��       '�� �     &	  �     '�� l    &	 �    &	 _    �� " ��.��� 	 � ��
 Z� �� 	 � ��
 Z� �� 	 � ��$
 40���� 	 � ��$
 40���� 	 � ��$

 10,5q� P�  � �� . . ��� 	 � ��$
 3q��� " ��.��� 	 � ��$
 5q��� 	 � ��$	
 100���� 	 � ��$
 Right=��� " ��.��� 	 � ��

 ������� 	 � ��$
 2q��� 	 �@��Padding$
 40q��� 	 � ��$
 0q��� " ��.��� 	 � ��$
 	5,10,0,10q��� 	 � ��$

 Left=��� 	 � ��$
 Center=��� 	 �@��Orientation$
 Vertical=��� " ��.��� 	 � ��$
 -40,-55q��� 	 � ��$

 Left=��� 	 � ��$	
 Top=��� 	 � ��

 ��İ�  .��� -    �Name$ MainGrid��
����İ� � RowDefinitions �� $
��auto ��� $��* �.+��� $
��Left=����� *SaveAndExit+.���� $6��0/RecognitionWPF;component/Images/SaveAndExit.png��.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ Click��.   (System.Windows.Interactivity.TriggerBase   Actions. >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ Close��   TargetObject ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL�� $��1�� �� $
��auto ��� $��* �.+�� -   $ MainParameters��$
��20,0q� �� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+��� -    ��Name$! CheckedMainCameraFrameCount��$��3��$
��Left=�$o��iИспользовать единое количество кадров при распознавании�� d� 	IsChecked �� *IsUseMainCameraFrameCount+�� $��3��$
��Left=�$��Center=��� $�(�� �� ��� *MinFrameCount+ �� $�-�� �� ��� *MaxFrameCount+ �� $�)���� $��3��{���  �� ElementName$! CheckedMainCameraFrameCount�� �� Path$ 	IsChecked����� *MainCameraFrameCount+�� -   $! CheckedMainTimeBetweenFrame��$��1��$��3��$
��Left=�$i��cИспользовать единый временной интервал между кадрами�� �� *IsUseMainTimeBetweenFrame+�� $��1��$��3��$
��Left=�$��Center=��� $�(от �� �� ��� *MinTimeBetweenFrame+ �� $�мс)���� $��1��$��3��{��� $! CheckedMainTimeBetweenFrame��$ 	IsChecked����� *MainTimeBetweenFrame+�� -   $" CheckedMainHeigthWordPercent��$��2��$��3��$
��Left=�$x��rИспользовать единую среднюю высоту символа при распознавании�� �� *IsUseMainHeigthWordPercent+�� $��2��$��3��$
��Left=�$��Center=��� $�(�� �� ��� *MinHeigthWordPercent+ �� $�-�� �� ��� *MaxHeigthWordPercent+ �� $�%)���� $��2��$��3��{��� $" CheckedMainHeigthWordPercent��$ 	IsChecked����� *MainHeigthWordPercent+� -   $ SingleParameters��$��1��$��20,20q� �� $��* ��� $
��auto ��� $��* ��� $
��auto � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��4��#��[  ._��� $��Камера 1��#��[ ��  �� Orientation$ Vertical=�.+��� $
��Left=�.��FDКоличество кадров при распознавании:�� $
��Left=�.��?=Средняя высота символа в кадре (%):�� $��1��$ Vertical=�.+��� ���� *Camera1FrameCount+.��{�`�  `� 	Converter# [ .1��� $ Camera1IsChecked��� $! CheckedMainCameraFrameCount��$ 	IsChecked�.���� ���� *Camera1HeigthWordPercent+.��{�`� # [ .1��� $ Camera1IsChecked��� $" CheckedMainHeigthWordPercent��$ 	IsChecked�.���� $��2��$ Vertical=�.+��� $
��Left=�.��GEВременной интервал между кадрами (мс):�� $
��Left=�$�� ���� $��3��$ Vertical=�.+��� ���� *Camera1TimeBetweenFrame+.��{�`� # [ .1��� $ Camera1IsChecked��� $! CheckedMainTimeBetweenFrame��$ 	IsChecked�.���� $�� ��$y�Hidden=��� $��1��$��4��#��[  ._��� $��Камера 2��#��[ �� $��1��$ Vertical=�.+��� $
��Left=�.��FDКоличество кадров при распознавании:�� $
��Left=�.��?=Средняя высота символа в кадре (%):�� $��1��$��1��$ Vertical=�.+��� ���� *Camera2FrameCount+.��{�`� # [ .1��� $ Camera2IsChecked��� $! CheckedMainCameraFrameCount��$ 	IsChecked�.���� ���� *Camera2HeigthWordPercent+.��{�`� # [ .1��� $ Camera2IsChecked��� $" CheckedMainHeigthWordPercent��$ 	IsChecked�.���� $��1��$��2��$ Vertical=�.+��� $
��Left=�.��GEВременной интервал между кадрами (мс):�� $
��Left=�$�� ���� $��1��$��3��$ Vertical=�.+��� ���� *Camera2TimeBetweenFrame+.��{�`� # [ .1��� $ Camera2IsChecked��� $! CheckedMainTimeBetweenFrame��$ 	IsChecked�.���� $�� ��$y�Hidden=��� $��2��$��4��#��[  ._��� $��Камера 3��#��[ �� $��2��$ Vertical=�.+��� $
��Left=�.��FDКоличество кадров при распознавании:�� $
��Left=�.��?=Средняя высота символа в кадре (%):�� $��2��$��1��$ Vertical=�.+��� ���� *Camera3FrameCount+.��{�`� # [ .1��� $ Camera3IsChecked��� $! CheckedMainCameraFrameCount��$ 	IsChecked�.���� ���� *Camera3HeigthWordPercent+.��{�`� # [ .1��� $ Camera3IsChecked��� $" CheckedMainHeigthWordPercent��$ 	IsChecked�.���� $��2��$��2��$ Vertical=�.+��� $
��Left=�.��GEВременной интервал между кадрами (мс):�� $
��Left=�$�� ���� $��2��$��3��$ Vertical=�.+��� ���� *Camera3TimeBetweenFrame+.��{�`� # [ .1��� $ Camera3IsChecked��� $! CheckedMainTimeBetweenFrame��$ 	IsChecked�.���� $�� ��$y�Hidden=��� $��3��$��4��#��[  ._��� $��Камера 4��#��[ �� $��3��$ Vertical=�.+��� $
��Left=�.��FDКоличество кадров при распознавании:�� $
��Left=�.��?=Средняя высота символа в кадре (%):�� $��3��$��1��$ Vertical=�.+��� ���� *Camera4FrameCount+.��{�`� # [ .1��� $ Camera4IsChecked��� $! CheckedMainCameraFrameCount��$ 	IsChecked�.���� ���� *Camera4HeigthWordPercent+.��{�`� # [ .1��� $ Camera4IsChecked��� $" CheckedMainHeigthWordPercent��$ 	IsChecked�.���� $��3��$��2��$ Vertical=�.+��� $
��Left=�.��GEВременной интервал между кадрами (мс):�� $
��Left=�$�� ���� $��3��$��3��$ Vertical=�.+��� ���� *Camera4TimeBetweenFrame+.��{�`� # [ .1��� $ Camera4IsChecked��� $! CheckedMainTimeBetweenFrame��$ 	IsChecked�.���� $�� ��$y�Hidden=�