package com.example.simondicefinal.activities

import android.os.Bundle
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import com.example.simondicefinal.R

class RulesActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_rules)

        // Al pulsar el botón volver cerrar la activity y vover a la anterior
        val btnExit = findViewById<Button>(R.id.BtnVolver)
        btnExit.setOnClickListener {
            finish()
        }

    }
}