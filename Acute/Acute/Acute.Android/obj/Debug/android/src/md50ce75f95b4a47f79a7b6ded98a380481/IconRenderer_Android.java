package md50ce75f95b4a47f79a7b6ded98a380481;


public class IconRenderer_Android
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.LabelRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FrazzApps.Xamarin.IconGenerator.Android.IconRenderer_Android, FrazzApps.Xamarin.IconGenerator.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", IconRenderer_Android.class, __md_methods);
	}


	public IconRenderer_Android (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == IconRenderer_Android.class)
			mono.android.TypeManager.Activate ("FrazzApps.Xamarin.IconGenerator.Android.IconRenderer_Android, FrazzApps.Xamarin.IconGenerator.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public IconRenderer_Android (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == IconRenderer_Android.class)
			mono.android.TypeManager.Activate ("FrazzApps.Xamarin.IconGenerator.Android.IconRenderer_Android, FrazzApps.Xamarin.IconGenerator.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public IconRenderer_Android (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == IconRenderer_Android.class)
			mono.android.TypeManager.Activate ("FrazzApps.Xamarin.IconGenerator.Android.IconRenderer_Android, FrazzApps.Xamarin.IconGenerator.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
