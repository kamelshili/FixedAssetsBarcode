package crc64053cca3b2898d050;


public class SingleItemTemplatedViewProviderContainer
	extends crc64053cca3b2898d050.TemplatedViewProviderContainer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Scheduler.Android.Internal.SingleItemTemplatedViewProviderContainer, DevExpress.Maui.Scheduler", SingleItemTemplatedViewProviderContainer.class, __md_methods);
	}


	public SingleItemTemplatedViewProviderContainer ()
	{
		super ();
		if (getClass () == SingleItemTemplatedViewProviderContainer.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Scheduler.Android.Internal.SingleItemTemplatedViewProviderContainer, DevExpress.Maui.Scheduler", "", this, new java.lang.Object[] {  });
		}
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
