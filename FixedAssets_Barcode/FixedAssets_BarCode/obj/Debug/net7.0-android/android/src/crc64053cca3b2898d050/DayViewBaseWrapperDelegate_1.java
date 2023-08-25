package crc64053cca3b2898d050;


public class DayViewBaseWrapperDelegate_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.scheduler.views.interop.NativeDayViewBaseInterop,
		com.devexpress.scheduler.views.interop.NativeGestureListener,
		com.devexpress.scheduler.views.interop.NativeIdleProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dayViewTopRowIndexChanged:(D)V:GetDayViewTopRowIndexChanged_DHandler:DevExpress.Android.Scheduler.Views.Interop.INativeDayViewBaseInteropInvoker, DevExpress.Android.Scheduler\n" +
			"n_requestContainers:(I)[Lcom/devexpress/scheduler/viewInfos/containers/DayContainerViewInfo;:GetRequestContainers_IHandler:DevExpress.Android.Scheduler.Views.Interop.INativeDayViewBaseInteropInvoker, DevExpress.Android.Scheduler\n" +
			"n_doubleTap:(Lcom/devexpress/scheduler/views/hittesting/SchedulerHitInfo;)V:GetDoubleTap_Lcom_devexpress_scheduler_views_hittesting_SchedulerHitInfo_Handler:DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerInvoker, DevExpress.Android.Scheduler\n" +
			"n_longPress:(Lcom/devexpress/scheduler/views/hittesting/SchedulerHitInfo;)V:GetLongPress_Lcom_devexpress_scheduler_views_hittesting_SchedulerHitInfo_Handler:DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerInvoker, DevExpress.Android.Scheduler\n" +
			"n_tap:(Lcom/devexpress/scheduler/views/hittesting/SchedulerHitInfo;)V:GetTap_Lcom_devexpress_scheduler_views_hittesting_SchedulerHitInfo_Handler:DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerInvoker, DevExpress.Android.Scheduler\n" +
			"n_idle:()V:GetIdleHandler:DevExpress.Android.Scheduler.Views.Interop.INativeIdleProviderInvoker, DevExpress.Android.Scheduler\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Scheduler.Android.Internal.DayViewBaseWrapperDelegate`1, DevExpress.Maui.Scheduler", DayViewBaseWrapperDelegate_1.class, __md_methods);
	}


	public DayViewBaseWrapperDelegate_1 ()
	{
		super ();
		if (getClass () == DayViewBaseWrapperDelegate_1.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Scheduler.Android.Internal.DayViewBaseWrapperDelegate`1, DevExpress.Maui.Scheduler", "", this, new java.lang.Object[] {  });
		}
	}


	public void dayViewTopRowIndexChanged (double p0)
	{
		n_dayViewTopRowIndexChanged (p0);
	}

	private native void n_dayViewTopRowIndexChanged (double p0);


	public com.devexpress.scheduler.viewInfos.containers.DayContainerViewInfo[] requestContainers (int p0)
	{
		return n_requestContainers (p0);
	}

	private native com.devexpress.scheduler.viewInfos.containers.DayContainerViewInfo[] n_requestContainers (int p0);


	public void doubleTap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0)
	{
		n_doubleTap (p0);
	}

	private native void n_doubleTap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0);


	public void longPress (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0)
	{
		n_longPress (p0);
	}

	private native void n_longPress (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0);


	public void tap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0)
	{
		n_tap (p0);
	}

	private native void n_tap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0);


	public void idle ()
	{
		n_idle ();
	}

	private native void n_idle ();

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
