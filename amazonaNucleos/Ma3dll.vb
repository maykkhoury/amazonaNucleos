Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Reflection

Namespace XRite
    Public Class MA3dll
        <DllImport("MA3.dll")>
        Public Shared Function Connect() As Boolean
        End Function

        <DllImport("MA3.dll")>
        Public Shared Function Disconnect() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function IsConnected() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetSpectralSetCount() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetWavelengthCount() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetWavelengthValue(ByVal index As Integer) As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function Measure() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetSpectralData(ByVal dataSet As Integer, ByVal wl As Integer) As Single

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function IsDataReady() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetCalStatus() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function Calibrate() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function CalibrateStep(ByVal calstep As String) As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetCalProgress() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function AbortCalibration() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ClearSamples() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetSampleCount() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function SetCurrentSample(ByVal sample As Integer) As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetSampleData(ByVal dataSet As Integer, ByVal wl As Integer) As Single

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function Configure() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function SetOption(ByVal setting As String, ByVal [option] As String) As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetLastErrorCode() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetSpectralSetName(ByVal index As Integer) As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetSerialNum() As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetCalSteps() As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetCalMode() As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetAvailableSettings() As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetSettingOptions(ByVal setting As String) As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetOption(ByVal setting As String) As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function GetLastErrorString() As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function Execute(ByVal cmdstring As String) As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ScanIsSupported() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ScanConfig(ByVal patchCount As Integer, ByVal patchWidth As Single) As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ScanStart() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ScanAbort() As Boolean

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ScanGetStatus() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ScanGetCount() As Integer

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ScanGetData(ByVal patchIndex As Integer, ByVal dataSet As Integer) As IntPtr

        End Function
        <DllImport("MA3.dll")>
        Public Shared Function ExecuteBinary(ByVal inputBuffer As Byte(), ByVal inputLength As UInteger, ByVal timeout As UInteger,
    <Out> ByVal outputBuffer As Byte(), ByVal outputBufferSize As UInteger) As Integer

        End Function
    End Class

    Public Class MA3
        Inherits MA3dll

        Public Overloads Function Connect() As Boolean
            Return MA3dll.Connect()
        End Function

        Public Overloads Function Execute(ByVal setting As String) As String
            Return Marshal.PtrToStringAnsi(MA3dll.Execute(setting))
        End Function

        Public Overloads Function SetCurrentSample(ByVal sample As Integer) As Boolean
            Return MA3dll.SetCurrentSample(sample)
        End Function
        Public Overloads Function GetWavelengthCount() As Integer
            Return MA3dll.GetWavelengthCount()
        End Function

        Public Overloads Function GetSpectralSetCount() As Integer
            Return MA3dll.GetSpectralSetCount()
        End Function

        Public Overloads Function GetWavelengthValue(ByVal index As Integer) As Integer
            Return MA3dll.GetWavelengthValue(index)
        End Function

        Public Overloads Function GetSpectralSetName(ByVal index As Integer) As String
            Return Marshal.PtrToStringAnsi(MA3dll.GetSpectralSetName(index))
        End Function

        Public Overloads Function GetSampleData(ByVal dataSet As Integer, ByVal wl As Integer) As Single
            Return MA3dll.GetSampleData(dataSet, wl)
        End Function
    End Class
End Namespace
