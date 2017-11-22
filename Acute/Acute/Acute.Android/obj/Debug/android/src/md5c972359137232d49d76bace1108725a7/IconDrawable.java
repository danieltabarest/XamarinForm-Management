package md5c972359137232d49d76bace1108725a7;


public class IconDrawable
	extends android.graphics.drawable.Drawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getIntrinsicHeight:()I:GetGetIntrinsicHeightHandler\n" +
			"n_getIntrinsicWidth:()I:GetGetIntrinsicWidthHandler\n" +
			"n_isStateful:()Z:GetIsStatefulHandler\n" +
			"n_getOpacity:()I:GetGetOpacityHandler\n" +
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_setState:([I)Z:GetSetState_arrayIHandler\n" +
			"n_setAlpha:(I)V:GetSetAlpha_IHandler\n" +
			"n_setColorFilter:(Landroid/graphics/ColorFilter;)V:GetSetColorFilter_Landroid_graphics_ColorFilter_Handler\n" +
			"n_clearColorFilter:()V:GetClearColorFilterHandler\n" +
			"";
		mono.android.Runtime.register ("Plugin.Iconize.Droid.Controls.IconDrawable, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", IconDrawable.class, __md_methods);
	}


	public IconDrawable () throws java.lang.Throwable
	{
		super ();
		if (getClass () == IconDrawable.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.Controls.IconDrawable, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public IconDrawable (android.content.Context p0, java.lang.String p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == IconDrawable.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.Controls.IconDrawable, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public int getIntrinsicHeight ()
	{
		return n_getIntrinsicHeight ();
	}

	private native int n_getIntrinsicHeight ();


	public int getIntrinsicWidth ()
	{
		return n_getIntrinsicWidth ();
	}

	private native int n_getIntrinsicWidth ();


	public boolean isStateful ()
	{
		return n_isStateful ();
	}

	private native boolean n_isStateful ();


	public int getOpacity ()
	{
		return n_getOpacity ();
	}

	private native int n_getOpacity ();


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);


	public boolean setState (int[] p0)
	{
		return n_setState (p0);
	}

	private native boolean n_setState (int[] p0);


	public void setAlpha (int p0)
	{
		n_setAlpha (p0);
	}

	private native void n_setAlpha (int p0);


	public void setColorFilter (android.graphics.ColorFilter p0)
	{
		n_setColorFilter (p0);
	}

	private native void n_setColorFilter (android.graphics.ColorFilter p0);


	public void clearColorFilter ()
	{
		n_clearColorFilter ();
	}

	private native void n_clearColorFilter ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
