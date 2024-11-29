package com.example.descubrelasestaciones

import java.io.Serializable

//  Aqui crearemos el json, para poder enviar los datos a la aplicación C#

class InfoNen (var avatar: String, var tempsTotal: Int, var tempsNVL1: Int,
               var tempsNVL2: Int, var tempsNVL3: Int, var tempsProm: Double,
               var erradesTotals: String, var erradesNVL1: String, var erradesNVL2: String,
               var erradesNVL3: String): Serializable