Public Class Formula
    Private id_formulaAtt As Integer

    Private formulaImgPathAtt As String

    Private otherPriceAtt As Double

    Private id_otherCurrenyAtt As Integer

    Private id_otherUnitAtt As Integer

    Private id_carAtt As Integer
    Private name_carAtt As String

    Private typeAtt As String
    Private versionAtt As String
    Private name_formulaAtt As String

    Private formulaVariantAtt As String
    Private duplicateAtt As String
    Private colorRGBAtt As String
    Private c_yearAtt As String
    Private colorCodeAtt As String
    Private clientNameAtt As String
    Private oldDbAtt As Boolean


    Private id_formulaXAtt As Integer
    Private id_formulaXpAtt As Integer
    Private id_formulaX2pAtt As Integer

    Private id_formulaYAtt As Integer
    Private id_formulaYpAtt As Integer
    Private id_formulaY2pAtt As Integer

    Private id_formulaZAtt As Integer
    Private id_formulaZpAtt As Integer
    Private id_formulaZ2pAtt As Integer
    Private cardNumberAtt As String
    Private movedAtt As Boolean = False
    Private dateCreModAtt As DateCreMod = Nothing

    Private isEquation4201_180Att As Boolean

    Private modified_onceAtt As Boolean = False
    Property modified_once() As Boolean
        Get
            Return modified_onceAtt
        End Get
        Set(ByVal Value As Boolean)
            modified_onceAtt = Value
        End Set

    End Property
    Property dateCreMod() As DateCreMod
        Get
            Return dateCreModAtt
        End Get
        Set(ByVal Value As DateCreMod)
            dateCreModAtt = Value
        End Set
    End Property
    Property isMoved() As Boolean
        Get
            Return movedAtt
        End Get
        Set(ByVal Value As Boolean)
            movedAtt = Value
        End Set
    End Property

    Property cardNumber() As String
        Get
            Return cardNumberAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                cardNumberAtt = Value.Trim
            End If

        End Set
    End Property
    Property id_formulaXp() As Integer
        Get
            Return id_formulaXpAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaXpAtt = Value
        End Set

    End Property
    Property id_formulaX2p() As Integer
        Get
            Return id_formulaX2pAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaX2pAtt = Value
        End Set

    End Property
    Property id_formulaYp() As Integer
        Get
            Return id_formulaYpAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaYpAtt = Value
        End Set

    End Property
    Property id_formulaY2p() As Integer
        Get
            Return id_formulaY2pAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaY2pAtt = Value
        End Set

    End Property
    Property id_formulaZp() As Integer
        Get
            Return id_formulaZpAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaZpAtt = Value
        End Set
    End Property
    Property id_formulaZ2p() As Integer
        Get
            Return id_formulaZ2pAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaZ2pAtt = Value
        End Set
    End Property
    Property id_formulaY() As Integer
        Get
            Return id_formulaYAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaYAtt = Value
        End Set

    End Property

    Property id_formulaX() As Integer
        Get
            Return id_formulaXAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaXAtt = Value
        End Set
    End Property
    Property id_formulaZ() As Integer
        Get
            Return id_formulaZAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaZAtt = Value
        End Set
    End Property
    Property oldDb() As Boolean
        Get
            Return oldDbAtt
        End Get
        Set(ByVal Value As Boolean)
            oldDbAtt = Value
        End Set
    End Property
    Property name_car() As String
        Get
            Return name_carAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                name_carAtt = Value.Trim
            End If
        End Set
    End Property
    Property clientName() As String
        Get
            Return clientNameAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                clientNameAtt = Value.Trim
            End If
        End Set
    End Property
    Property c_year() As String
        Get
            Return c_yearAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                c_yearAtt = Value.Trim
            End If
        End Set
    End Property

    Property colorRGB() As String
        Get
            Return colorRGBAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                colorRGBAtt = Value.Trim
            End If
        End Set
    End Property


    Property colorCode() As String
        Get
            Return colorCodeAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                colorCodeAtt = Value.Trim
            End If
        End Set
    End Property

    Property duplicate() As String
        Get
            Return duplicateAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                duplicateAtt = Value.Trim
            End If
        End Set
    End Property

    Property formulaVariant() As String
        Get
            Return formulaVariantAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                formulaVariantAtt = Value.Trim
            End If
        End Set
    End Property

    Property name_formula() As String
        Get
            Return name_formulaAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                name_formulaAtt = Value.Trim
            End If
        End Set
    End Property

    Property version() As String
        Get
            Return versionAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                versionAtt = Value.Trim
            End If
        End Set
    End Property


    Property type() As String
        Get
            Return typeAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                typeAtt = Value.Trim
            End If
        End Set
    End Property



    Property id_formula() As Integer
        Get
            Return id_formulaAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaAtt = Value
        End Set
    End Property

    Property id_car() As Integer
        Get
            Return id_carAtt
        End Get
        Set(ByVal Value As Integer)
            id_carAtt = Value
        End Set
    End Property

    Property formulaImgPath() As String
        Get
            Return formulaImgPathAtt
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing Then
                formulaImgPathAtt = Value.Trim
            End If
        End Set
    End Property


    Property otherPrice() As Double
        Get
            Return otherPriceAtt
        End Get
        Set(ByVal Value As Double)
            otherPriceAtt = Value
        End Set
    End Property


    Property id_otherCurreny() As Integer
        Get
            Return id_otherCurrenyAtt
        End Get
        Set(ByVal Value As Integer)
            id_otherCurrenyAtt = Value
        End Set
    End Property


    Property id_otherUnit() As Integer
        Get
            Return id_otherUnitAtt
        End Get
        Set(ByVal Value As Integer)
            id_otherUnitAtt = Value
        End Set
    End Property
    Property isEquation4201_180() As Boolean
        Get
            Return isEquation4201_180Att
        End Get
        Set(ByVal Value As Boolean)
            isEquation4201_180Att = Value
        End Set
    End Property

End Class
