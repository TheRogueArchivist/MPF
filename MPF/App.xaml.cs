﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

#if NET35_OR_GREATER || NETCOREAPP

        /// <summary>
        /// ComboBoxTemplate ControlTemplate XAML (.NET Framework 4.0 and above)
        /// </summary>
        private const string _comboBoxTemplateDefault = @"<ControlTemplate TargetType=""{x:Type ComboBox}"">
            <Grid x:Name=""templateRoot"" SnapsToDevicePixels=""true"">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width=""*""/>
                    <ColumnDefinition MinWidth=""{DynamicResource {x:Static SystemParameters.VerticalScrollBarWidthKey}}"" Width=""0""/>
                </Grid.ColumnDefinitions>
                <Popup x:Name=""PART_Popup"" AllowsTransparency=""true"" Grid.ColumnSpan=""2"" IsOpen=""{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"" Margin=""1"" PopupAnimation=""{DynamicResource {x:Static SystemParameters.ComboBoxPopupAnimationKey}}"" Placement=""Bottom"">
                    <themes:SystemDropShadowChrome x:Name=""shadow"" Color=""Transparent"" MaxHeight=""{TemplateBinding MaxDropDownHeight}"" MinWidth=""{Binding ActualWidth, ElementName=templateRoot}"">
                        <Border x:Name=""dropDownBorder"" BorderBrush=""{DynamicResource {x:Static SystemColors.WindowFrameBrushKey}}"" BorderThickness=""1"" Background=""{DynamicResource {x:Static SystemColors.WindowBrushKey}}"">
                            <ScrollViewer x:Name=""DropDownScrollViewer"">
                                <Grid x:Name=""grid"" RenderOptions.ClearTypeHint=""Enabled"">
                                    <Canvas x:Name=""canvas"" HorizontalAlignment=""Left"" Height=""0"" VerticalAlignment=""Top"" Width=""0"">
                                        <Rectangle x:Name=""opaqueRect"" Fill=""{Binding Background, ElementName=dropDownBorder}"" Height=""{Binding ActualHeight, ElementName=dropDownBorder}"" Width=""{Binding ActualWidth, ElementName=dropDownBorder}""/>
                                    </Canvas>
                                    <ItemsPresenter x:Name=""ItemsPresenter"" KeyboardNavigation.DirectionalNavigation=""Contained"" SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""/>
                                </Grid>
                            </ScrollViewer>
                        </Border>
                    </themes:SystemDropShadowChrome>
                </Popup>
                <ToggleButton x:Name=""toggleButton"" BorderBrush=""{TemplateBinding BorderBrush}"" BorderThickness=""{TemplateBinding BorderThickness}"" Background=""{TemplateBinding Background}"" Grid.ColumnSpan=""2"" IsChecked=""{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"" Style=""{DynamicResource ComboBoxToggleButton}""/>
                <ContentPresenter x:Name=""contentPresenter"" ContentTemplate=""{TemplateBinding SelectionBoxItemTemplate}"" ContentTemplateSelector=""{TemplateBinding ItemTemplateSelector}"" Content=""{TemplateBinding SelectionBoxItem}"" ContentStringFormat=""{TemplateBinding SelectionBoxItemStringFormat}"" HorizontalAlignment=""{TemplateBinding HorizontalContentAlignment}"" IsHitTestVisible=""false"" Margin=""{TemplateBinding Padding}"" SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}"" VerticalAlignment=""{TemplateBinding VerticalContentAlignment}""/>
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property=""HasDropShadow"" SourceName=""PART_Popup"" Value=""true"">
                    <Setter Property=""Margin"" TargetName=""shadow"" Value=""0,0,5,5""/>
                    <Setter Property=""Color"" TargetName=""shadow"" Value=""#71000000""/>
                </Trigger>
                <Trigger Property=""HasItems"" Value=""false"">
                    <Setter Property=""Height"" TargetName=""dropDownBorder"" Value=""95""/>
                </Trigger>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property=""IsGrouping"" Value=""true""/>
                        <Condition Property=""VirtualizingPanel.IsVirtualizingWhenGrouping"" Value=""false""/>
                    </MultiTrigger.Conditions>
                    <Setter Property=""ScrollViewer.CanContentScroll"" Value=""false""/>
                </MultiTrigger>
                <Trigger Property=""ScrollViewer.CanContentScroll"" SourceName=""DropDownScrollViewer"" Value=""false"">
                    <Setter Property=""Canvas.Top"" TargetName=""opaqueRect"" Value=""{Binding VerticalOffset, ElementName=DropDownScrollViewer}""/>
                    <Setter Property=""Canvas.Left"" TargetName=""opaqueRect"" Value=""{Binding HorizontalOffset, ElementName=DropDownScrollViewer}""/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>";

        /// <summary>
        /// ComboBoxTemplate ControlTemplate XAML (.NET Framework 3.5)
        /// </summary>
        private const string _comboBoxTemplateNet35 = @"<ControlTemplate TargetType=""{x:Type ComboBox}"">
            <Grid x:Name=""templateRoot"" SnapsToDevicePixels=""true"">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width=""*""/>
                    <ColumnDefinition MinWidth=""{DynamicResource {x:Static SystemParameters.VerticalScrollBarWidthKey}}"" Width=""0""/>
                </Grid.ColumnDefinitions>
                <Popup x:Name=""PART_Popup"" AllowsTransparency=""true"" Grid.ColumnSpan=""2"" IsOpen=""{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"" Margin=""1"" PopupAnimation=""{DynamicResource {x:Static SystemParameters.ComboBoxPopupAnimationKey}}"" Placement=""Bottom"">
                    <Border x:Name=""dropDownBorder"" BorderBrush=""{DynamicResource {x:Static SystemColors.WindowFrameBrushKey}}"" BorderThickness=""1"" Background=""{DynamicResource {x:Static SystemColors.WindowBrushKey}}"">
                        <ScrollViewer x:Name=""DropDownScrollViewer"">
                            <Grid x:Name=""grid"">
                                <Canvas x:Name=""canvas"" HorizontalAlignment=""Left"" Height=""0"" VerticalAlignment=""Top"" Width=""0"">
                                    <Rectangle x:Name=""opaqueRect"" Fill=""{Binding Background, ElementName=dropDownBorder}"" Height=""{Binding ActualHeight, ElementName=dropDownBorder}"" Width=""{Binding ActualWidth, ElementName=dropDownBorder}""/>
                                </Canvas>
                                <ItemsPresenter x:Name=""ItemsPresenter"" KeyboardNavigation.DirectionalNavigation=""Contained"" SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""/>
                            </Grid>
                        </ScrollViewer>
                    </Border>
                </Popup>
                <ToggleButton x:Name=""toggleButton"" BorderBrush=""{TemplateBinding BorderBrush}"" BorderThickness=""{TemplateBinding BorderThickness}"" Background=""{TemplateBinding Background}"" Grid.ColumnSpan=""2"" IsChecked=""{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"" Style=""{DynamicResource ComboBoxToggleButton}""/>
                <ContentPresenter x:Name=""contentPresenter"" ContentTemplate=""{TemplateBinding SelectionBoxItemTemplate}"" ContentTemplateSelector=""{TemplateBinding ItemTemplateSelector}"" Content=""{TemplateBinding SelectionBoxItem}"" ContentStringFormat=""{TemplateBinding SelectionBoxItemStringFormat}"" HorizontalAlignment=""{TemplateBinding HorizontalContentAlignment}"" IsHitTestVisible=""false"" Margin=""{TemplateBinding Padding}"" SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}"" VerticalAlignment=""{TemplateBinding VerticalContentAlignment}""/>
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property=""HasItems"" Value=""false"">
                    <Setter Property=""Height"" TargetName=""dropDownBorder"" Value=""95""/>
                </Trigger>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property=""IsGrouping"" Value=""true""/>
                    </MultiTrigger.Conditions>
                    <Setter Property=""ScrollViewer.CanContentScroll"" Value=""false""/>
                </MultiTrigger>
                <Trigger Property=""ScrollViewer.CanContentScroll"" SourceName=""DropDownScrollViewer"" Value=""false"">
                    <Setter Property=""Canvas.Top"" TargetName=""opaqueRect"" Value=""{Binding VerticalOffset, ElementName=DropDownScrollViewer}""/>
                    <Setter Property=""Canvas.Left"" TargetName=""opaqueRect"" Value=""{Binding HorizontalOffset, ElementName=DropDownScrollViewer}""/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>";

        /// <summary>
        /// ComboBoxEditableTemplate ControlTemplate XAML (.NET Framework 4.0 and above)
        /// </summary>
        private const string _comboBoxEditableTemplateDefault = @"<ControlTemplate TargetType=""{x:Type ComboBox}"">
            <Grid x:Name=""templateRoot"" SnapsToDevicePixels=""true"">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width=""*""/>
                    <ColumnDefinition MinWidth=""{DynamicResource {x:Static SystemParameters.VerticalScrollBarWidthKey}}"" Width=""0""/>
                </Grid.ColumnDefinitions>
                <Popup x:Name=""PART_Popup"" AllowsTransparency=""true"" Grid.ColumnSpan=""2"" IsOpen=""{Binding IsDropDownOpen, RelativeSource={RelativeSource TemplatedParent}}"" PopupAnimation=""{DynamicResource {x:Static SystemParameters.ComboBoxPopupAnimationKey}}"" Placement=""Bottom"">
                    <themes:SystemDropShadowChrome x:Name=""shadow"" Color=""Transparent"" MaxHeight=""{TemplateBinding MaxDropDownHeight}"" MinWidth=""{Binding ActualWidth, ElementName=templateRoot}"">
                        <Border x:Name=""dropDownBorder"" BorderBrush=""{DynamicResource {x:Static SystemColors.WindowFrameBrushKey}}"" BorderThickness=""1"" Background=""{DynamicResource {x:Static SystemColors.WindowBrushKey}}"">
                            <ScrollViewer x:Name=""DropDownScrollViewer"">
                                <Grid x:Name=""grid"" RenderOptions.ClearTypeHint=""Enabled"">
                                    <Canvas x:Name=""canvas"" HorizontalAlignment=""Left"" Height=""0"" VerticalAlignment=""Top"" Width=""0"">
                                        <Rectangle x:Name=""opaqueRect"" Fill=""{Binding Background, ElementName=dropDownBorder}"" Height=""{Binding ActualHeight, ElementName=dropDownBorder}"" Width=""{Binding ActualWidth, ElementName=dropDownBorder}""/>
                                    </Canvas>
                                    <ItemsPresenter x:Name=""ItemsPresenter"" KeyboardNavigation.DirectionalNavigation=""Contained"" SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""/>
                                </Grid>
                            </ScrollViewer>
                        </Border>
                    </themes:SystemDropShadowChrome>
                </Popup>
                <ToggleButton x:Name=""toggleButton"" BorderBrush=""{TemplateBinding BorderBrush}"" BorderThickness=""{TemplateBinding BorderThickness}"" Background=""{TemplateBinding Background}"" Grid.ColumnSpan=""2"" IsChecked=""{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"" Style=""{DynamicResource ComboBoxToggleButton}""/>
                <Border x:Name=""border"" Background=""{DynamicResource TextBox.Static.Background}"" Margin=""{TemplateBinding BorderThickness}"">
                    <TextBox x:Name=""PART_EditableTextBox"" HorizontalContentAlignment=""{TemplateBinding HorizontalContentAlignment}"" IsReadOnly=""{Binding IsReadOnly, RelativeSource={RelativeSource TemplatedParent}}"" Margin=""{TemplateBinding Padding}"" Style=""{DynamicResource ComboBoxEditableTextBox}"" VerticalContentAlignment=""{TemplateBinding VerticalContentAlignment}""/>
                </Border>
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property=""IsEnabled"" Value=""false"">
                    <Setter Property=""Opacity"" TargetName=""border"" Value=""0.56""/>
                </Trigger>
                <Trigger Property=""IsKeyboardFocusWithin"" Value=""true"">
                    <Setter Property=""Foreground"" Value=""Black""/>
                </Trigger>
                <Trigger Property=""HasDropShadow"" SourceName=""PART_Popup"" Value=""true"">
                    <Setter Property=""Margin"" TargetName=""shadow"" Value=""0,0,5,5""/>
                    <Setter Property=""Color"" TargetName=""shadow"" Value=""#71000000""/>
                </Trigger>
                <Trigger Property=""HasItems"" Value=""false"">
                    <Setter Property=""Height"" TargetName=""dropDownBorder"" Value=""95""/>
                </Trigger>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property=""IsGrouping"" Value=""true""/>
                        <Condition Property=""VirtualizingPanel.IsVirtualizingWhenGrouping"" Value=""false""/>
                    </MultiTrigger.Conditions>
                    <Setter Property=""ScrollViewer.CanContentScroll"" Value=""false""/>
                </MultiTrigger>
                <Trigger Property=""ScrollViewer.CanContentScroll"" SourceName=""DropDownScrollViewer"" Value=""false"">
                    <Setter Property=""Canvas.Top"" TargetName=""opaqueRect"" Value=""{Binding VerticalOffset, ElementName=DropDownScrollViewer}""/>
                    <Setter Property=""Canvas.Left"" TargetName=""opaqueRect"" Value=""{Binding HorizontalOffset, ElementName=DropDownScrollViewer}""/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>";

        /// <summary>
        /// ComboBoxEditableTemplate ControlTemplate XAML (.NET Framework 3.5)
        /// </summary>
        private const string _comboBoxEditableTemplateNet35 = @"<ControlTemplate TargetType=""{x:Type ComboBox}"">
            <Grid x:Name=""templateRoot"" SnapsToDevicePixels=""true"">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width=""*""/>
                    <ColumnDefinition MinWidth=""{DynamicResource {x:Static SystemParameters.VerticalScrollBarWidthKey}}"" Width=""0""/>
                </Grid.ColumnDefinitions>
                <Popup x:Name=""PART_Popup"" AllowsTransparency=""true"" Grid.ColumnSpan=""2"" IsOpen=""{Binding IsDropDownOpen, RelativeSource={RelativeSource TemplatedParent}}"" PopupAnimation=""{DynamicResource {x:Static SystemParameters.ComboBoxPopupAnimationKey}}"" Placement=""Bottom"">
                    <Border x:Name=""dropDownBorder"" BorderBrush=""{DynamicResource {x:Static SystemColors.WindowFrameBrushKey}}"" BorderThickness=""1"" Background=""{DynamicResource {x:Static SystemColors.WindowBrushKey}}"">
                        <ScrollViewer x:Name=""DropDownScrollViewer"">
                            <Grid x:Name=""grid"">
                                <Canvas x:Name=""canvas"" HorizontalAlignment=""Left"" Height=""0"" VerticalAlignment=""Top"" Width=""0"">
                                    <Rectangle x:Name=""opaqueRect"" Fill=""{Binding Background, ElementName=dropDownBorder}"" Height=""{Binding ActualHeight, ElementName=dropDownBorder}"" Width=""{Binding ActualWidth, ElementName=dropDownBorder}""/>
                                </Canvas>
                                <ItemsPresenter x:Name=""ItemsPresenter"" KeyboardNavigation.DirectionalNavigation=""Contained"" SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""/>
                            </Grid>
                        </ScrollViewer>
                    </Border>
                </Popup>
                <ToggleButton x:Name=""toggleButton"" BorderBrush=""{TemplateBinding BorderBrush}"" BorderThickness=""{TemplateBinding BorderThickness}"" Background=""{TemplateBinding Background}"" Grid.ColumnSpan=""2"" IsChecked=""{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"" Style=""{DynamicResource ComboBoxToggleButton}""/>
                <Border x:Name=""border"" Background=""{DynamicResource TextBox.Static.Background}"" Margin=""{TemplateBinding BorderThickness}"">
                    <TextBox x:Name=""PART_EditableTextBox"" HorizontalContentAlignment=""{TemplateBinding HorizontalContentAlignment}"" IsReadOnly=""{Binding IsReadOnly, RelativeSource={RelativeSource TemplatedParent}}"" Margin=""{TemplateBinding Padding}"" Style=""{DynamicResource ComboBoxEditableTextBox}"" VerticalContentAlignment=""{TemplateBinding VerticalContentAlignment}""/>
                </Border>
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property=""IsEnabled"" Value=""false"">
                    <Setter Property=""Opacity"" TargetName=""border"" Value=""0.56""/>
                </Trigger>
                <Trigger Property=""IsKeyboardFocusWithin"" Value=""true"">
                    <Setter Property=""Foreground"" Value=""Black""/>
                </Trigger>
                <Trigger Property=""HasItems"" Value=""false"">
                    <Setter Property=""Height"" TargetName=""dropDownBorder"" Value=""95""/>
                </Trigger>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property=""IsGrouping"" Value=""true""/>
                    </MultiTrigger.Conditions>
                    <Setter Property=""ScrollViewer.CanContentScroll"" Value=""false""/>
                </MultiTrigger>
                <Trigger Property=""ScrollViewer.CanContentScroll"" SourceName=""DropDownScrollViewer"" Value=""false"">
                    <Setter Property=""Canvas.Top"" TargetName=""opaqueRect"" Value=""{Binding VerticalOffset, ElementName=DropDownScrollViewer}""/>
                    <Setter Property=""Canvas.Left"" TargetName=""opaqueRect"" Value=""{Binding HorizontalOffset, ElementName=DropDownScrollViewer}""/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>";

        /// <summary>
        /// CustomProgressBarStyle Style XAML (.NET Framework 4.0 and above)
        /// </summary>
        private const string _customProgressBarStyleDefault = @"<Style x:Key=""CustomProgressBarStyle"" TargetType=""{x:Type ProgressBar}"">
            <Setter Property=""Foreground"" Value=""{DynamicResource ProgressBar.Progress}""/>
            <Setter Property=""Background"" Value=""{DynamicResource ProgressBar.Background}""/>
            <Setter Property=""BorderBrush"" Value=""{DynamicResource ProgressBar.Border}""/>
            <Setter Property=""BorderThickness"" Value=""1""/>
            <Setter Property=""Template"">
                <Setter.Value>
                    <ControlTemplate TargetType=""{x:Type ProgressBar}"">
                        <Grid x:Name=""TemplateRoot"">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name=""CommonStates"">
                                    <VisualState x:Name=""Determinate""/>
                                    <VisualState x:Name=""Indeterminate"">
                                        <Storyboard RepeatBehavior=""Forever"">
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=""(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"" Storyboard.TargetName=""Animation"">
                                                <EasingDoubleKeyFrame KeyTime=""0"" Value=""0.25""/>
                                                <EasingDoubleKeyFrame KeyTime=""0:0:1"" Value=""0.25""/>
                                                <EasingDoubleKeyFrame KeyTime=""0:0:2"" Value=""0.25""/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <PointAnimationUsingKeyFrames Storyboard.TargetProperty=""(UIElement.RenderTransformOrigin)"" Storyboard.TargetName=""Animation"">
                                                <EasingPointKeyFrame KeyTime=""0"" Value=""-0.5,0.5""/>
                                                <EasingPointKeyFrame KeyTime=""0:0:1"" Value=""0.5,0.5""/>
                                                <EasingPointKeyFrame KeyTime=""0:0:2"" Value=""1.5,0.5""/>
                                            </PointAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Border BorderBrush=""{TemplateBinding BorderBrush}"" BorderThickness=""{TemplateBinding BorderThickness}"" Background=""{TemplateBinding Background}""/>
                            <Rectangle x:Name=""PART_Track""/>
                            <Grid x:Name=""PART_Indicator"" ClipToBounds=""true"" HorizontalAlignment=""Left"">
                                <Rectangle x:Name=""Indicator"" Fill=""{TemplateBinding Foreground}""/>
                                <Rectangle x:Name=""Animation"" Fill=""{TemplateBinding Foreground}"" RenderTransformOrigin=""0.5,0.5"">
                                    <Rectangle.RenderTransform>
                                        <TransformGroup>
                                            <ScaleTransform/>
                                            <SkewTransform/>
                                            <RotateTransform/>
                                            <TranslateTransform/>
                                        </TransformGroup>
                                    </Rectangle.RenderTransform>
                                </Rectangle>
                            </Grid>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property=""Orientation"" Value=""Vertical"">
                                <Setter Property=""LayoutTransform"" TargetName=""TemplateRoot"">
                                    <Setter.Value>
                                        <RotateTransform Angle=""-90""/>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                            <Trigger Property=""IsIndeterminate"" Value=""true"">
                                <Setter Property=""Visibility"" TargetName=""Indicator"" Value=""Collapsed""/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>";

        /// <summary>
        /// CustomProgressBarStyle Style XAML (.NET Framework 3.5)
        /// </summary>
        private const string _customProgressBarStyleNet35 = @"<Style TargetType=""{x:Type ProgressBar}"">
            <Setter Property=""Foreground"" Value=""{DynamicResource ProgressBar.Progress}""/>
            <Setter Property=""Background"" Value=""{DynamicResource ProgressBar.Background}""/>
            <Setter Property=""BorderBrush"" Value=""{DynamicResource ProgressBar.Border}""/>
            <Setter Property=""BorderThickness"" Value=""1""/>
            <Setter Property=""Template"">
                <Setter.Value>
                    <ControlTemplate TargetType=""{x:Type ProgressBar}"">
                        <Grid x:Name=""TemplateRoot"">
                            <Border BorderBrush=""{TemplateBinding BorderBrush}"" BorderThickness=""{TemplateBinding BorderThickness}"" Background=""{TemplateBinding Background}""/>
                            <Rectangle x:Name=""PART_Track""/>
                            <Grid x:Name=""PART_Indicator"" ClipToBounds=""true"" HorizontalAlignment=""Left"">
                                <Rectangle x:Name=""Indicator"" Fill=""{TemplateBinding Foreground}""/>
                                <Rectangle x:Name=""Animation"" Fill=""{TemplateBinding Foreground}"" RenderTransformOrigin=""0.5,0.5"">
                                    <Rectangle.RenderTransform>
                                        <TransformGroup>
                                            <ScaleTransform/>
                                            <SkewTransform/>
                                            <RotateTransform/>
                                            <TranslateTransform/>
                                        </TransformGroup>
                                    </Rectangle.RenderTransform>
                                </Rectangle>
                            </Grid>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property=""Orientation"" Value=""Vertical"">
                                <Setter Property=""LayoutTransform"" TargetName=""TemplateRoot"">
                                    <Setter.Value>
                                        <RotateTransform Angle=""-90""/>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                            <Trigger Property=""IsIndeterminate"" Value=""true"">
                                <Setter Property=""Visibility"" TargetName=""Indicator"" Value=""Collapsed""/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>";
        public App()
        {
            InitializeComponent();

            CreateControlTemplate("ComboBoxTemplate");
            CreateControlTemplate("ComboBoxEditableTemplate");
            CreateProgressBarStyle();
        }

        /// <summary>
        /// Create an XAML parser context with the required namespaces
        /// </summary>
        private ParserContext CreateParserContext()
        {
            var context = new ParserContext();

            context.XmlnsDictionary[""] = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
            context.XmlnsDictionary["x"] = "http://schemas.microsoft.com/winfx/2006/xaml";
#if NETFRAMEWORK
            context.XmlnsDictionary["themes"] = "clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero";
#else
            context.XmlnsDictionary["themes"] = "clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2";
#endif
            context.XamlTypeMapper = new XamlTypeMapper([]);

            return context;
        }

        /// <summary>
        /// Create a named control template and add it to the current set of resources
        /// </summary>
        private void CreateControlTemplate(string resourceName)
        {
            var parserContext = CreateParserContext();
            var controlTemplate = resourceName switch
            {
#if NET35
                "ComboBoxTemplate" => XamlReader.Parse(_comboBoxTemplateNet35, parserContext) as ControlTemplate,
                "ComboBoxEditableTemplate" => XamlReader.Parse(_comboBoxEditableTemplateNet35, parserContext) as ControlTemplate,
#else
                "ComboBoxTemplate" => XamlReader.Parse(_comboBoxTemplateDefault, parserContext) as ControlTemplate,
                "ComboBoxEditableTemplate" => XamlReader.Parse(_comboBoxEditableTemplateDefault, parserContext) as ControlTemplate,
#endif
                _ => throw new ArgumentException($"'{resourceName}' is not a recognized control template", nameof(resourceName)),
            };

            // Add the control template
            Resources[resourceName] = controlTemplate;
        }

        /// <summary>
        /// Create the custom progress bar style and add it to the current set of resources
        /// </summary>
        private void CreateProgressBarStyle()
        {
            var parserContext = CreateParserContext();
#if NET35
            var style = XamlReader.Parse(_customProgressBarStyleNet35, parserContext) as Style;
#else
            var style = XamlReader.Parse(_customProgressBarStyleDefault, parserContext) as Style;
#endif

            // Add the style
            Resources["CustomProgressBarStyle"] = style;
        }
#endif
    }
}
