package com.example.descubrelasestaciones

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity

class PantallaFinal:AppCompatActivity()
{
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.final_layout)
        val buttonVolver = findViewById<Button>(R.id.buttonTerminar)

        buttonVolver.setOnClickListener {
            val intent = Intent(this, MainActivity::class.java) // Reemplaza `MainActivity` con la actividad que deseas abrir
            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
            startActivity(intent)
            finish()
        }
    }
}