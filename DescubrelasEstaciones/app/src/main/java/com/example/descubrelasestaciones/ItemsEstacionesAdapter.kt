package com.example.descubrelasestaciones;

import android.content.Context;
import android.media.Image
import android.view.LayoutInflater
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

        fun bind(item: ItemEstaciones) {
            imgItemEstaciones.setImageResource(item.imagen)
            itemView.setOnLongClickListener {
                longClickListener?.invoke(it, adapterPosition)
                // Cambia la opacidad al arrastrar
                itemView.alpha = 0.5f  // Reduce la opacidad
                true
            }
        }
    }

    fun clearAlpha() {
        notifyDataSetChanged() // Restablece la opacidad de todos los ítems
    }
}
