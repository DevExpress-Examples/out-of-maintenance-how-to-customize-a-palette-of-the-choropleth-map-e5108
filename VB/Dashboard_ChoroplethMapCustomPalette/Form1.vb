Imports System.Collections.Generic
Imports System.Drawing
Imports DevExpress.DashboardCommon
Imports DevExpress.XtraEditors

Namespace Dashboard_ChoroplethMapCustomPalette
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			' Loads a dashboard that contains a choropleth map with the default palette.
			Dim dashboard As New Dashboard()
			dashboard.LoadFromXml("..\..\Data\Dashboard.xml")

			' Gets the ValueMap object that provides data for coloring map shapes.
			Dim map As ChoroplethMapDashboardItem = CType(dashboard.Items(0), ChoroplethMapDashboardItem)
			Dim populationMap As ValueMap = CType(map.Maps(0), ValueMap)

			' Creates CustomPalette and CustomScale objects.
			Dim customPalette As New CustomPalette()
			Dim customScale As New CustomScale()

			' Creates lists of custom colors and range stops.
			Dim customColors As New List(Of Color)()
			Dim rangeStops As New List(Of Double)()

			' Specifies that the absolute scale is used to define a set of colors.
			customScale.IsPercent = False

			' Specifies custom colors and corresponding range stops.   
			customColors.Add(Color.LightBlue)
			rangeStops.Add(100000)
			customColors.Add(Color.SkyBlue)
			rangeStops.Add(1000000)
			customColors.Add(Color.LightCoral)
			rangeStops.Add(10000000)
			customColors.Add(Color.Tomato)
			rangeStops.Add(100000000)
			customColors.Add(Color.Maroon)
			rangeStops.Add(1000000000)

			' Adds custom colors and range stops to a custom palette and corresponding custom scale.
			customPalette.Colors.AddRange(customColors)
			customScale.RangeStops.AddRange(rangeStops)

			' Specifies a custom palette and scale for the ValueMap object.
			populationMap.Palette = customPalette
			populationMap.Scale = customScale

			' Sets the customized dashboard as a currently opened dashboard.
			dashboardViewer1.Dashboard = dashboard
		End Sub
	End Class
End Namespace
