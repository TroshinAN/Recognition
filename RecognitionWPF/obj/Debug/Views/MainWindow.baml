   M S B A M L   `   `   `  ����I  ERecognitionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecognitionWPF.ModelsRecognitionWPF.Models  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      E'clr-namespace:RecognitionWPF.ViewModelsRecognitionWPF.ViewModels  5	      [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5
      %    RecognitionWPF.Views.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6custom#clr-namespace:RecognitionWPF.Models     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6vm'clr-namespace:RecognitionWPF.ViewModels     5	      Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5
        � Title$$  Видеоанализатор��5      $
��1024��5      $	��768��5      $	��800��5      $	��600��5       � Icon$/ )/RecognitionWPF;component/Images/Icon.ico��5       � SizeToContent$ Manual=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      3   -RecognitionWPF.ViewModels.MainWindowViewModel  5   
    � 	Resources 5         ImageButtonOn �� 	UriSource  ImageButtonOnDisable  ImageButtonOff  ImageButtonOffDisable  ImageButtonPause  ImageButtonPlay  ImageButtonPlayDisable  ImageButtonRecognFrame ! ImageButtonRecognFrameDisable 	 ImageButtonStop 
 ImageButtonStopDisable  ImageButtonClearReport  ImageButtonClose  ImageButtonMultyMonitor  ImageButtonSaveAndExit  ImageButtonSetting  	AllButton �� 
TargetType �� Property	 �� Value
 �� Triggers P� Property P� Value  ButtonsClear �� BasedOn  	DoButtons  ButtonImageInit  ButtonImageInitRecognition �� Binding �� Value  ButtonImageInitCameras  ButtonImagePlay  ButtonImagePlayRecognition  ButtonImagePlayCameras  ButtonImageRecognitionFrame  ButtonImageCamerasStop  ButtonImageMultyCamera  ButtonImageCamerasSetting��%u  &	        &	 G     &	 �     &	 �     &	 ,    &	 v    &	 �    &	     &	 _    &		 �    &	
 �    &	 O    &	 �    &	 �    &	 (    &	 r    &	 �    &	 }    7  &	 �    7  &	 g    7   7  &	 '    7  7  7  &	 L    7  7  7  &	 d	    7  7  &	 $
    7  7 	 &	 �
    7  7  &	 u    7  7  7  &	 �    7 	 7 
 &	 o    7  &	 �    7  �� 5   
   $3 -/RecognitionWPF;component/Images/ButtonOn.png?�6,   �� 5   
   $: 4/RecognitionWPF;component/Images/ButtonOnDisable.png?�63   �� 5   
   $4 ./RecognitionWPF;component/Images/ButtonOff.png?�6-   �� 5   
   $; 5/RecognitionWPF;component/Images/ButtonOffDisable.png?�64   �� 5   
   $6 0/RecognitionWPF;component/Images/ButtonPause.png?�6/   �� 5   
   $5 //RecognitionWPF;component/Images/ButtonPlay.png?�6.   �� 5   
   $< 6/RecognitionWPF;component/Images/ButtonPlayDisable.png?�65   �� 5    
   $< 6/RecognitionWPF;component/Images/ButtonRecognFrame.png?�65   �� 5!   
   $C =/RecognitionWPF;component/Images/ButtonRecognFrameDisable.png?�6<   �� 5"   
   $5 //RecognitionWPF;component/Images/ButtonStop.png?�6.   �� 5#   
   $< 6/RecognitionWPF;component/Images/ButtonStopDisable.png?�65   �� 5$   
   $6 0/RecognitionWPF;component/Images/ClearReport.png?�65   �� 5%   
   $0 */RecognitionWPF;component/Images/Close.png?�6/   �� 5&   
   $7 1/RecognitionWPF;component/Images/MultyMonitor.png?�66   �� 5'   
   $6 0/RecognitionWPF;component/Images/SaveAndExit.png?�65   �� 5(   
   $2 ,/RecognitionWPF;component/Images/Setting.png?�61   �� 5*   
   " ��6"   .�5+      ��  � ��	 6+   Z� �� 5,       � ��	 6,   Z� 
 5-      P� 5.       � �� . . �5/      ��  � ��$	 3q�60   50      52      �� 53   
   8   " ��56      .�57      ��  � ��$	 30��6&   �� 58       � ��$	 30��6'   59      �� 5:   
   8   " ��5=      .�5>      ��  � ��$	 40��6&   �� 5?       � ��$	 40��6'   5@      �� 5B   
   " ��6(   
 5C      P� 5D       � {� . . �5E      ��  � ��8	   6/   5F      P� 5G       � {� .  . �5H      ��  � ��8	  6/   5I      5K      �� 5L   
   8   " ��5O      
 5P      �� 5Q       6   �� *IsRecognitionLibraryInit+ True6K   .a�5R      ��  � ��8	  6/   5S      �� 5T       6   �� *" IsRecognitionRunTimeFrameProcess+ True6S   .a�5U      ��  � ��8	  6/   5V      5X      �� 5Y   
   8   " ��5\      
 5]      �� 5^       6   �� *IsCameraLibraryInit+ True6F   .a�5_      ��  � ��8	  6/   5`      �� 5a       6   �� *IsRecognitionLibraryInit+ True6K   .a�5b      ��  � ��8	  6/   5c      5e      �� 5g   
   " ��6(   
 5h      P� 5i       � {� . . �5j      ��  � ��8	   6/   5k      P� 5l       � {� .  . �5m      ��  � ��8	  6/   5n      5p      �� 5q   
   8   " ��5t      
 5u      �� 5v       6   �� *" IsRecognitionRunTimeFrameProcess+ True6S   .a�5w      ��  � ��8	  6/   5x      5z      �� 5{   
   8   " ��5~      
 5      �� 5�       6   �� *IsCamerasPlay+ True6@   .a�5�      ��  � ��8	  6/   5�      5�      �� 5�   
   " ��64   
 5�      P� 5�       � {� . . �5�      ��  � ��8	   6/   5�      P� 5�       � {� .  . �5�      ��  � ��8	  6/   5�      �� 5�       6   �� *!IsRecognitionSingleFrameProcess+ True6R   .a�5�      ��  � ��8	  6/   5�      5�      �� 5�   
   " ��6/   
 5�      P� 5�       � {� . . �5�      ��  � ��8	   6/   5�      P� 5�       � {� .  . �5�      ��  � ��8	  6/   5�      5�      �� 5�   
   " ��6/   .�5�      ��  � ��8	   6'   5�      �� 5�   
   " ��62   .�5�      ��  � ��8	   6'   5�      5�      .��5�      � -   5         �Name$ MainGrid��5�      
����İ� � RowDefinitions 5�   
   �� 5�      $��* �6   �� 5�      $��50 �6   �� 5�      $
��0.3* �6    � ColumnDefinitions 5�   
   �� 5�      $
��2.5* �6   �� 5�      $��* �6   .+�5�   
   � -   5        $ FunctionalGrid��5�      $��0��5�      $��0��5�      $��2��5�      $��10q�5�       5�      �� 5�      $
��2.5* �6#   �� 5�      $��* �6#   .+�5�      � -   5        $ Cameras��5�      $��0��5�      $��0,0,5,0q�5�      
���   � 5�      �� 5�      $��* �6'   �� 5�      $��* �6'    5�      �� 5�      $��* �6$   �� 5�      $��* �6$   .+�5�      � -   5        $ BorderCamera1��5�      $��0��5�      $��0��5�      .+�5�      �� 
�������$��1q�68   ._�5�      7  1System.Windows.Forms.Integration.WindowsFormsHost     Child. 5�      %  System.Windows.Forms.PictureBox  -   5        Camera1��"  System.Windows.Forms.Control   	BackColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$ Black 5�   =   5�      5�      5�      � 5�      -   5        $ BorderCamera2��5�      $��0��5�      $��1��5�      .+�5�      �� 
�������$��1q�68   ._�5�        . 5�        -   5        Camera2��$ Black 5�   =   5�      5�      5�      � 5�      -   5        $ BorderCamera3��5�      $��1��5�      $��0��5�      .+�5�      �� 
�������$��1q�68   ._�5�        . 5�        -	   5        Camera3��$ Black 5�   =   5�      5�      5�      � 5�      -
   5        $ BorderCamera4��5�      $��1��5�      $��1��5�      .+�5�      �� 
�������$��1q�68   ._�5�        . 5�        -   5        Camera4��$ Black 5�   =   5�      5�      5�      5�      � 5�      -   5        $ Recognition��5�      $��1��5�      $��5,0,0,0q�5�       5�      �� 5�      $��50 �6$   �� 5�      $��* �6$   .+�5�      � -   5        $ RecognitionControlPanel��5�      $��0��5�       K� ZIndex$ 1��5�      
����İ� 5�      �� 5�      $��* �6+   �� 5      $��* �6+   �� 5     $��* �6+   .+�5     �� -   5         ��Name$ RecognitionInitButton��5     $��0��5     $��5q�5     $
��Left=�5     $��Center=�5     #��[ 5
     ��5	     �� *InitRecognitionLibrary+.��5     �� #��[ 6    5     � 5     $��1��6    5     �� 5     $��* �6/   �� 5     $��* �6/   .+�5     �� -   5        $ RecognitionAnalizeVideo��5     $��0��5     $��Center=�5     $��Center=�5     #��[ 5     ��5     �� *RecognitionRunTimeFrame+.��5     �� #��[ 6$   5     �� 5     -   5        $ RecognitionAnalizeFrame��5     $��1��5     $��Center=�5     $��Center=�5     #��[ 5!     ��5      �� *RecognitionSingleFrame+.��5"     �� #��[ 6$   5#     5$     �� 5%     $��2��5&     $	��0,5q�5'     $��Right=�5(     $��Center=�5)     #��[ 5+     ��5*     �� *RecognitionSetting+.��5,     �� #��[ 6    5-     5.     �� 5/     $��1��50     $
��auto��51     $	��0,5q�52     $
��Left=�53     ��54     �� *RecognitionStatus+�� 55     $��1��56     $��0q�57     $��Right=�58     $	��Top=�59     $ 3��5:     #��[ 5<     ��5;     �� *ClearRecognitionDataGrid+.��5=     �� #��[ 6   5>     &   System.Windows.Controls.DataGrid  5?     -   5          Name$ RecognitionDataGrid��5@     $��1��5A     $��0,30,0,0q�5B        AlternatingRowBackground
 ��·� �� AlternationCount$ 2��5D        AutoGenerateColumns .  
����ح�   CanUserAddRows .   J� IsManipulationEnabled .     
IsReadOnly .    SelectionMode$ Single=�5K     ��5J     �� *RecognitionResults+   Columns 5L     0  *System.Windows.Controls.DataGridTextColumn  5M     ,  &System.Windows.Controls.DataGridColumn    Width5	  /System.Windows.Controls.DataGridLengthConverter$  3*	 5N     !   Header$! 
Время��5P     1
  +System.Windows.Controls.DataGridBoundColumn" 
  Binding" 5O     �� *Time+# �� StringFormat$# {0:G}��5P       5Q     $
  1.5*	 5R     $! Номервагона��5T     $ �� TextAlignment$$ Center=�5U     " 5S     �� *Number+5U       5V     $
  1.5*	 5W     $! Точность��5Y     " 5X     �� *
Confidence+5Y     .  (System.Windows.Interactivity.Interaction%   	Behaviors% 5[     +   %RecognitionWPF.Models.ScrollOnNewItem  5\     5^     5_     5`     � 5a  
   -   5        $ CamerasControlPanel��5b     $��1��5c     $��0��5d     $��10,0,0,0q�5e      5f     �� 5g     $��2* �6#   �� 5h     $��1* �6#   �� 5i     $��2* �6#   .+�5k     � $��0��6   .+�5l     �� -   5        $ CamerasInit��5m     $��0��5n     $��5q�5o     $
��Left=�5p     $��Center=�5q     #��[ 5s     ��5r     �� *InitCameraLibrary+.��5t     �� #��[ 6   5u     5v     � 5w     $��1��6    5x     �� 5y     $��* �6'   �� 5z     $��* �6'   .+�5|     �� $��0��5}     $��Center=�5~     $��Center=�5     #��[ 5�     ��5�     �� *CamerasStop+.��5�     �� #��[ 6   5�     �� 5�     $��1��5�     $��Center=�5�     $��Center=�5�     #��[ 5�     ��5�     �� *CamerasPlay+.��5�     �� #��[ 6   5�     5�     � 5�     $��2��6    5�     �� 5�     $��* �6'   �� 5�     $��* �6'   .+�5�     �� $��0��5�     $��50��5�     $��50��5�     $
��10,0q�5�     $
��Left=�5�     $��Center=�5�     #��[ 5�     ��5�     �� *MultyCamera+.��5�     �� #��[ 6   5�     �� 5�     $��1��5�     $
��10,5q�5�     $��Right=�5�     $��Center=�5�     #��[ 5�     ��5�     �� *CamerasSetting+.��5�     �� #��[ 6   5�     5�     5�     � 5�  
   -   5        $ 
SystemInfo��5�     $��2��5�     $��	10,0,0,10q�5�     .+�5�     �� $��0q�5�     $
��Left=�5�     $	��Top=�5�     #��[ 5�     ��5�     �� *ClearInfoMessages+.��5�     �� #��[ 6   5�     �� 5�     -   5        & ��Name$& InfoMessages��5�     $��	30,0,10,0q�5�     ��5�     �� *InfoMessages+' �� SelectedItem' 5�     �� *SelectedIndexMessage+% 5�       5�     5�     5�     5�     5�     