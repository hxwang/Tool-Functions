Option Explicit
 
Sub AddProgressBars()
    Dim oPres As Presentation
    Dim oSlide As Slide
    Dim oShape As Shape
    Dim oText As Shape
    Dim iBlueBarLength As Long
    Dim iVisiableSlides As Long
    Dim iSlideIndex As Long
    Dim iWidth As Long
    Dim iHeight As Long
     
    Call DeleteProgressBars
     
    Set oPres = ActivePresentation
     'make sure there's a presentation
    If ActivePresentation Is Nothing Then Exit Sub
    If ActivePresentation.Slides.Count < 4 Then Exit Sub
    
  Rem MsgBox oPres.SectionProperties.SlidesCount(1)
  
  iWidth = oPres.PageSetup.SlideWidth
  iHeight = oPres.PageSetup.SlideHeight
  
  Rem MsgBox iWidth & " " & iHeight
    
    For Each oSlide In oPres.Slides
        If Not oSlide.SlideShowTransition.Hidden Then
            iVisiableSlides = iVisiableSlides + 1
        End If
    Next
    
    For Each oSlide In oPres.Slides
         
         'add red background
        'Set oShape = oSlide.Shapes.AddShape(msoShapeRectangle, 0, 0, oPres.PageSetup.SlideWidth - 1, 6)
         
        'With oShape
           ' .Name = "ProgressBarRed"
           ' .Line.Weight = 0.5
           ' .Line.ForeColor.RGB = RGB(127, 207, 59)
           ' .Fill.Solid
           ' .Fill.ForeColor.RGB = RGB(255, 255, 5255)
        'End With
        
        If Not oSlide.SlideShowTransition.Hidden Then
             iSlideIndex = iSlideIndex + 1
             
             
            
            Set oText = oSlide.Shapes.AddTextbox(msoTextOrientationHorizontal, 0, 0, 200, 20)
            
            Dim sectionName As String
            Dim sectionSlidesCount As Long
            sectionName = oPres.SectionProperties.Name(oSlide.sectionIndex)
            sectionSlidesCount = oPres.SectionProperties.SlidesCount(oSlide.sectionIndex)
            Dim sectionFirstSlide As Long
            sectionFirstSlide = oPres.SectionProperties.FirstSlide(oSlide.sectionIndex)
            
            
                
            If sectionSlidesCount > 3 Then
            
                With oText
                    .Name = "TitleBox"
                    .TextFrame.TextRange.Text = sectionName
                    .TextFrame.TextRange.ParagraphFormat.Alignment = ppAlignLeft
                    .Left = iWidth / 2 - .Width / 2
                    .Top = iHeight - .Height
                    .TextFrame.TextRange.Font.Color.RGB = RGB(128, 128, 128) ' font color
                End With
            
                'add progress bar
                iBlueBarLength = oPres.PageSetup.SlideWidth * (oSlide.SlideIndex - sectionFirstSlide + 1)
                iBlueBarLength = iBlueBarLength / (sectionSlidesCount)
                 
                Set oShape = oSlide.Shapes.AddShape(msoShapeRectangle, 0, iHeight - 4, iBlueBarLength, 4)
                 
                With oShape
                    .Name = "ProgressBar"
                    .Line.ForeColor.RGB = RGB(255, 127, 127)
                    .Fill.Solid
                    .Fill.ForeColor.RGB = RGB(255, 127, 127)
                End With
            End If
        
        End If
         
    Next
     
     
End Sub
 
Sub DeleteProgressBars()
    Dim oPres As Presentation
    Dim oSlide As Slide
    Dim oShape As Shape
     
     'make sure there's a presentation
    If ActivePresentation Is Nothing Then Exit Sub
     
     
    Set oPres = ActivePresentation
    For Each oSlide In oPres.Slides
        On Error Resume Next
        oSlide.Shapes("ProgressBarRed").Delete
        oSlide.Shapes("ProgressBarBlue").Delete
        oSlide.Shapes("ProgressBar").Delete
        oSlide.Shapes("TitleBox").Delete
        On Error GoTo 0
    Next
End Sub

