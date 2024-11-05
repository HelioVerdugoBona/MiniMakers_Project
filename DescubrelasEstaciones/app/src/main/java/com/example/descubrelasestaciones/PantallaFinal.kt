package com.example.descubrelasestaciones

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import com.example.descubrelasestaciones.ColoresEstaciones.ColoresConstats

class PantallaFinal:AppCompatActivity()
{

    object InfoNens {
        const val INFONEN = "INFONEN"
    }

    private var infoNen = InfoNen("Error","Error","Error","Error","Error",
        "Error","Error","Error","Error","Error")

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.final_layout)
        val buttonVolver = findViewById<Button>(R.id.buttonTerminar)

        val intent = intent
        infoNen = intent.getSerializableExtra(ColoresConstats.INFONEN) as InfoNen
        setAllInformation(infoNen)
        buttonVolver.setOnClickListener {
            val intent = Intent(this, MainActivity::class.java) // Reemplaza `MainActivity` con la actividad que deseas abrir
            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
            startActivity(intent)
            finish()
        }


    }

    private fun setAllInformation(infoNen: InfoNen) {
        val tmpTotal = infoNen.tempsNVL1.toInt() + infoNen.tempsNVL2.toInt() + infoNen.tempsNVL3.toInt()
        infoNen.tempsTotal = tmpTotal.toString()
        infoNen.tempsProm = (tmpTotal/3).toString()
        println("La Info total es:" + " Avatar: " + infoNen.avatar + " Tiempo nivel 1: " + infoNen.tempsNVL1
                + " Tiempo nivel 2: " + infoNen.tempsNVL2 + " Tiempo nivel 3:  " + infoNen.tempsNVL3
                + " Tiempo Total: " + infoNen.tempsTotal + " Tiempo Promedio: " + infoNen.tempsProm
                + " Intentos Nivel 1: " + infoNen.intentsNVL1 + " Intentos Nivel 2: " + infoNen.intentsNVL2
                + " Intentos Nivel 3: " + infoNen.intentsNVL3 + " IntentosTotales: " + infoNen.intentsTotals)
    }
}