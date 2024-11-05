package com.example.descubrelasestaciones

import android.annotation.SuppressLint
import android.content.ClipData
import android.content.Context
import android.view.LayoutInflater
import android.view.MotionEvent
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class ItemsEstacionesAdapter(
    private val context: Context,
    private val itemsEstaciones: MutableList<ItemEstaciones>
) : RecyclerView.Adapter<ItemsEstacionesAdapter.ItemsEstacionesViewHolder>()
{
    private var longClickListener: ((View, Int) -> Unit)? = null
    private val layout = R.layout.item_image

    fun setOnLongClickListener(listener: (View, Int) -> Unit) {
        longClickListener = listener
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ItemsEstacionesViewHolder
    {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)
        return ItemsEstacionesViewHolder(view)
    }

    override fun getItemCount(): Int = itemsEstaciones.size

    override fun onBindViewHolder(holder: ItemsEstacionesViewHolder, position: Int) {
        val itemEstacion = itemsEstaciones[position]
        holder.bind(itemEstacion)
    }

    inner class ItemsEstacionesViewHolder(val view: View) : RecyclerView.ViewHolder(view) {

        var imgItemEstaciones = view.findViewById<ImageView>(R.id.imageView)

        @SuppressLint("ClickableViewAccessibility")
        fun bind(item: ItemEstaciones) {
            imgItemEstaciones.setImageResource(item.imagen)
            itemView.setOnTouchListener { view, event ->
                if (event.action == MotionEvent.ACTION_DOWN) {
                    // Inicia el arrastre con una sombra personalizada
                    val dragData = ClipData.newPlainText("id", item.id)
                    val dragShadow = CustomDragShadowBuilder(view) // Usar la sombra personalizada
                    itemView.startDragAndDrop(dragData, dragShadow, view, 0)
                    true
                } else {
                    false
                }
            }
//            itemView.setOnLongClickListener {
//                longClickListener?.invoke(it, adapterPosition)
//                // Cambia la opacidad al arrastrar
//                itemView.alpha = 0.5f  // Reduce la opacidad
//                true
//            }
        }
    }

    fun clearAlpha() {
        notifyDataSetChanged() // Restablece la opacidad de todos los ítems
    }
}
