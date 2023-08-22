################################################################################################
################            CODIGO DE PYTHON PARA GRAFICAR LAS PRUEBAS          ################
################                DE CONTROL, TECLADO Y lEAP MOTION               ################
################            EN LA TESIS DE RUBEN PAREDES, ASESORADO POR         ################
################                    M.A. LUIS YAIR BAUTISTA BLANCO              ################
################################################################################################

#Import required libraries
import os, datetime
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from openpyxl.workbook import Workbook
from tkinter.filedialog import test
import matplotlib.dates as md
from datetime import datetime
import dateutil


#Constants required
CurrentDirectory = os.path.dirname(os.path.abspath(__file__))
DataFileName = 'Data de Pruebas.xlsx'

####################################################################
################# Funciones ########################################
####################################################################

# Reads an excel sheet
def read_excel(CurrentDirectory, DataFileName):
    DataFile = pd.ExcelFile (DataFileName)
    sheets = DataFile.book.worksheets
    movimientos=['1', '2', '3', '4', '5','6','7', '8','9','10', '11','12','13',"14","15"]
    contador = 1
    
    
    DT = []
    DC = []
    DL = []
        
    for sheet in sheets:
        #No lee las hojas de excel ocultas
        if(sheet.sheet_state != 'visible'):
            continue
        #Nombre de la prueba    
        sheetName = sheet.title
        previousN = "Abdiel"
        #Graficas Delta de Tiempo
        if (sheetName == "Delta de Tiempo"):
            dataTest = pd.read_excel(DataFile, sheet.title, skiprows = 2, usecols=lambda x: 'Movimientos' not in x )
            users = []
            print("Delta de Tiempo")
            tipo = "Delta de Tiempo"
            #Columnas
            for col in dataTest.columns:    
                extractName = col.replace('_Leap','').replace('_Teclado','').replace('_Control','')
                users.append(extractName)
                deltaTime = dataTest[col].apply(lambda x:((x.hour*60+x.minute)*60+x.second))
                
                if(previousN != extractName):
                    #Funcion graficadora
                    # print("previousName: ", previousN)
                    # print("extractName: ", extractName)
                    grafica_mov(movimientos,DT,DC,DL,previousN,contador,tipo)
                    previousN = extractName
                    contador=contador+1
                    DT = []; DC = []; DL = []
                
                if("Teclado" in str(col)):
                    DT=deltaTime
                elif("Control" in col):
                    DC=deltaTime
                elif("Leap" in col):
                    DL=deltaTime
            grafica_mov(movimientos,DT,DC,DL,previousN,contador,tipo)
    
        #Graficas Curva de Aprendizaje
        
        DT = []; DC = []; DL = []
        contador = 1
        if (sheetName == "Curva de Aprendizaje"):
            print("Curva de Aprendizaje")
            dataTest = pd.read_excel(DataFile, sheet.title, skiprows = 2, usecols=lambda x: 'Movimientos' not in x )
            users = []
            tipo = "Curva de Aprendizaje"
            #Columnas
            for col in dataTest.columns:    
                extractName = col.replace('_Leap','').replace('_Teclado','').replace('_Control','')
                users.append(extractName)
                deltaTime = dataTest[col].apply(lambda x:((x.hour*60+x.minute)*60+x.second))
                
                if(previousN != extractName):
                    #Funcion graficadora
                    # print("previousName: ", previousN)
                    # print("extractName: ", extractName)
                    grafica_mov(movimientos,DT,DC,DL,previousN,contador,tipo)
                    previousN = extractName
                    contador=contador+1
                    DT = []; DC = []; DL = []
                
                if("Teclado" in str(col)):
                    DT=deltaTime
                elif("Control" in col):
                    DC=deltaTime
                elif("Leap" in col):
                    DL=deltaTime
            grafica_mov(movimientos,DT,DC,DL,previousN,contador,tipo)
            
        #Graficas Movimientos Totales
        if (sheetName == "Movimientos Totales"):
            dataTest = pd.read_excel(DataFile, sheet.title)
            print("Movimientos Totales")
            #print(dataTest)
        
        #Graficas Ancho de Banda
        if (sheetName == "Ancho de Banda"):
            dataTest = pd.read_excel(DataFile, sheet.title)
            print("Ancho de Banda")
            #print(dataTest)
        
        #Graficas Delta Ancho de Banda
        if (sheetName == "Delta Ancho de Banda"):
            dataTest = pd.read_excel(DataFile, sheet.title)
            print("Delta Ancho de Banda")
            # print(dataTest)
        
    return()

def grafica_mov(movimientos, DT, DC, DL, name,testNumber,tipo):    
    plt.style.use('seaborn-v0_8-dark-palette')
    #Teclado
    plt.plot(movimientos, DT, "x-", label = "Teclado", c = '#50BAFE')
    #Control
    plt.plot(movimientos, DC, "o-", label = "Control", c = '#39FD91')
    if(len(DL) != 0):
        #LEAP
        plt.plot(movimientos, DL, "+-", label = "Leap", c = '#690069')
    plt.xlabel('Instrucción (n)', fontsize = 10)
    plt.ylabel('Tiempo (s)', fontsize = 10)    
    plt.title("Prueba " + str(testNumber) + " " + name + " "+tipo, fontsize = 16)
    plt.legend()
    plt.savefig("PrimeData/"+ tipo + "/"+ "Prueba "+ str(testNumber) +" " + name + " " + tipo +".png")
    plt.close()      

#################################
### Programa principal
#################################
if __name__ == '__main__':
    read_excel(CurrentDirectory, DataFileName)
    
    
