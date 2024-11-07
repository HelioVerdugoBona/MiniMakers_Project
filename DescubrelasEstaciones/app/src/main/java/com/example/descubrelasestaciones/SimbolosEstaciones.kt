package com.example.descubrelasestaciones

import android.content.ClipData
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.DragEvent
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.descubrelasestaciones.ColoresEstaciones.ColoresConstats

class SimbolosEstaciones: AppCompatActivity ()
{

    object SimbolosConstats {
        const val INFONEN = "INFONEN"
    }

    private var startTime = System.currentTimeMillis()
    private var intentos = 0
    private var infoNen = InfoNen("Error","Error","Error","Error","Error",
        "Error","Error","Error","Error","Error")

    private val itemsEstaciones = mutableListOf(
        ItemEstaciones("1", "Sol", R.drawable.sol),
        ItemEstaciones("2", "Flor", R.drawable.flor),
        ItemEstaciones("3", "Hoja", R.drawable.hoja),
        ItemEstaciones("4", "Copo_Nieve", R.drawable.coponieve)
    )

    private val arrayEstaciones = mutableListOf(
        ItemEstaciones("1", "Verano", R.drawable.estiu),
        ItemEstaciones("2", "Primavera", R.drawable.primavera),
        ItemEstaciones("3", "Otoño", R.drawable.tardor),
        ItemEstaciones("4", "Invierno", R.drawable.hivern)
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.simbolos_estaciones)
        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewSimbolos)
        val arrayEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewSimbolos2)

        val intent = intent
        infoNen = intent.getSerializableExtra(ColoresConstats.INFONEN) as InfoNen
        setupRecyclerView(itemEstacionesList, itemsEstaciones,arrayEstacionesList,arrayEstaciones)
    }

    private fun setupRecyclerView(
        recyclerView1: RecyclerView,
        itemsEstaciones: MutableList<ItemEstaciones>,
        recyclerView2: RecyclerView,
        arrayEstaciones: MutableList<ItemEstaciones>
    ) {
        val adapterItem = ItemsEstacionesAdapter(this, itemsEstaciones, true)
        recyclerView1.layoutManager = LinearLayoutManager(this)
        recyclerView1.layoutManager = GridLayoutManager(this,4)
        recyclerView1.adapter = adapterItem


        val adapterEstacion = ItemsEstacionesAdapter(this, arrayEstaciones, false)
        recyclerView2.layoutManager = LinearLayoutManager(this)
        recyclerView2.layoutManager = GridLayoutManager(this,4)
        recyclerView2.adapter = adapterEstacion


        recyclerView2.setOnDragListener { _, event ->
            when (event.action) {
                DragEvent.ACTION_DROP -> {
                    // val draggedItem = event.localState as ItemEstaciones
                    // Obtener el atributo del ítem arrastrado
                    val draggedAttribute = event.clipData.getItemAt(0).text.toString()
                    println("El ID del draggedAttribute es: $draggedAttribute")

                    // Encuentra el ítem de destino (donde se soltó el arrastre)
                    val x = event.x
                    val y = event.y
                    val viewUnder = recyclerView2.findChildViewUnder(x, y)
                    val targetPosition = if (viewUnder != null) {
                        recyclerView2.getChildAdapterPosition(viewUnder)
                    } else {
                        RecyclerView.NO_POSITION
                    }
                    println("El targetPosition es: $targetPosition")


                    if (targetPosition != RecyclerView.NO_POSITION) {
                        val targetItem = arrayEstaciones[targetPosition]

                        // Compara los atributos
                        if (draggedAttribute == targetItem.id) {
                            val iterator = itemsEstaciones.iterator()
                            while (iterator.hasNext()) {
                                val item = iterator.next()
                                if (draggedAttribute == item.id) {
                                    iterator.remove() // Elimina usando el iterador
                                    adapterItem.notifyDataSetChanged()
                                    break // Salir del bucle después de eliminar
                                }
                            }
                            if(itemsEstaciones.size == 0){
                                nextLevel()
                            }
                            Log.d("DragAndDrop", "Atributos coinciden")

                        } else {
                            Log.d("DragAndDrop", "Atributos no coinciden")
                            intentos++
                        }
                    }
                    true
                }
                DragEvent.ACTION_DRAG_ENDED -> {

                    true
                }

                else -> true
            }
        }
    }

    private fun nextLevel() {
        val intent = Intent(this, RopasEstaciones::class.java)
        val endTime = System.currentTimeMillis()
        val elapsedTime = endTime - startTime // en milisegundos
        Log.d("Timer", "Tiempo transcurrido: ${elapsedTime}ms")
        infoNen.tempsNVL2 = (elapsedTime/1000).toString()
        infoNen.erradesNVL2 = intentos.toString()
        intent.putExtra(RopasEstaciones.RopasConstats.INFONEN,infoNen)
        startActivity(intent)
    }

}