package com.example.descubrelasestaciones

import android.content.Intent
import android.media.MediaPlayer
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.util.Log
import android.view.DragEvent
import android.view.View
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.airbnb.lottie.LottieAnimationView


class Tutorial:AppCompatActivity()
{

    object TutoriaConstats {
        const val INFONEN = "INFONEN"
    }

    private lateinit var mediaPlayer: MediaPlayer
    private lateinit var confetti: MediaPlayer
    private lateinit var yay: MediaPlayer
    private lateinit var aconseguit: MediaPlayer

     private var infoNen = InfoNen("Error",0,0,0,0,
        0.00,"Error","Error","Error","Error")

    private lateinit var anmConfetti: LottieAnimationView

    private val itemsEstaciones = mutableListOf<ItemEstaciones>()

    private val arrayEstaciones = mutableListOf<ItemEstaciones>()


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.tutorial_layout)

        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)
        mediaPlayer = MediaPlayer.create(this, R.raw.musicafondo)

        anmConfetti = findViewById(R.id.ANMConfetti)
        confetti = MediaPlayer.create(this, R.raw.confetti)
        yay = MediaPlayer.create(this, R.raw.yay)
        itemsEstaciones.add(ItemEstaciones("3", "Naranja", R.drawable.colornaranja,MediaPlayer.create(this, R.raw.taronja)))
        arrayEstaciones.add(ItemEstaciones("3", "Otoño", R.drawable.tardor,MediaPlayer.create(this, R.raw.tardor)))
        aconseguit = MediaPlayer.create(this, R.raw.hohasaconseguit)

        if (mediaPlayer != null) {
            // Configurar la música para que se repita
            mediaPlayer.isLooping = true

            // Iniciar la reproducción
            mediaPlayer.start()
        } else {
            Log.e("MediaPlayerError", "MediaPlayer no se pudo inicializar.")
        }
        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewTutorial)
        val arrayEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewTutorialEstaciones)

        val intent = intent
        infoNen = intent.getSerializableExtra(TutoriaConstats.INFONEN) as InfoNen
        setupRecyclerView(itemEstacionesList, itemsEstaciones,arrayEstacionesList,arrayEstaciones)

    }

    private fun setupRecyclerView(
        recyclerView1: RecyclerView,
        itemsEstaciones: MutableList<ItemEstaciones>,
        recyclerView2: RecyclerView,
        arrayEstaciones: MutableList<ItemEstaciones>
    ) {

        itemsEstaciones.shuffle()
        arrayEstaciones.shuffle()

        val adapterItem = ItemsEstacionesAdapter(this, itemsEstaciones, true)
        recyclerView1.layoutManager = LinearLayoutManager(this)

        recyclerView1.adapter = adapterItem

        val adapterEstacion = ItemsEstacionesAdapter(this, arrayEstaciones, false)
        recyclerView2.layoutManager = GridLayoutManager(this,4)
        recyclerView2.adapter = adapterEstacion

        recyclerView1.setOnDragListener { _, event ->
            when (event.action) {
                DragEvent.ACTION_DRAG_STARTED  -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 0f

                    val targetPosition =
                    if (draggedView != null) {
                            recyclerView1.getChildAdapterPosition(draggedView)
                        } else {
                            RecyclerView.NO_POSITION
                        }
                    val item = itemsEstaciones[targetPosition]
                    item.sound.start()
                    true
                }else -> true

            }
        }

        recyclerView2.setOnDragListener { view, event ->
            when (event.action) {
                DragEvent.ACTION_DROP -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 1.0f

                    val draggedAttribute = event.clipData.getItemAt(0).text.toString()
                    view.alpha = 1.0f
                    // Encuentra el ítem de destino (donde se soltó el arrastre)
                    val x = event.x
                    val y = event.y
                    val viewUnder = recyclerView2.findChildViewUnder(x, y)
                    val targetPosition =
                        if (viewUnder != null) {
                            recyclerView2.getChildAdapterPosition(viewUnder)
                        } else {
                            RecyclerView.NO_POSITION
                        }

                    println("El targetPosition es: $targetPosition")

                    if (targetPosition != RecyclerView.NO_POSITION) {
                        val targetItem = arrayEstaciones[targetPosition]
                        targetItem.sound.start()
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
                            if(itemsEstaciones.size == 0){ // Aqui pasa al siguiente nivel

                                val txtFelicitar: TextView = findViewById(R.id.txtFelicitar)
                                txtFelicitar.visibility = View.VISIBLE
                                anmConfetti.playAnimation()
                                confetti.start()
                                yay.start()

                                aconseguit.start()
                                Handler(Looper.getMainLooper()).postDelayed({
                                    nextLevel()
                                }, 1500)

                            }
                            Log.d("DragAndDrop", "Atributos coinciden")

                        } else {
                            Log.d("DragAndDrop", "Atributos no coinciden")
                        }
                    }
                    true
                }
                DragEvent.ACTION_DRAG_ENDED -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 1.0f
                    true
                }
                else -> true
            }
        }
    }

    private fun nextLevel() {
        val intent = Intent(this, ColoresEstaciones::class.java)
        intent.putExtra(ColoresEstaciones.ColoresConstats.INFONEN, infoNen)
        startActivity(intent)
    }

}